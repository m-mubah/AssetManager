using AssetManager.Core;
using AssetManager.Core.DTO.Staff;
using AssetManager.Core.Entities.Staff;
using AssetManager.Core.Services.Staffs;
using AssetManager.Infrastructure;
using AssetManager.Infrastructure.Contexts;
using AssetManager.Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Services.Staff
{
    public class StaffService : IStaffService
    {
        private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;

        public StaffService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Gets all staff
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Core.Entities.Staff.Staff>> GetAll()
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                return await context.Staffs.Where(i => i.Id != ModelConstants.Staff.SystemAdministrator).ToListAsync();
            }
        }

        /// <summary>
        /// Gets a staff by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AddEditStaffDTO> GetByIdAsync(Guid id)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                var staff = await context.Staffs.FirstOrDefaultAsync(i => i.Id == id);
                var user = await context.Users.FirstOrDefaultAsync(i => i.StaffId == id);

                IdentityUserRole<string> role = null;
                
                if (user != null)
                {
                    role = await context.UserRoles.FirstOrDefaultAsync(i => i.UserId == user.Id);
                }

                var editStaffDTO = new AddEditStaffDTO
                {
                    Staff = staff,
                    Username = user?.UserName ?? "",
                    Password = "",
                    Email = user?.Email ?? "",
                    HasAdminAccess = role != null ? true : false,
                    HasLogin = user != null ? true : false,
                };

                return editStaffDTO;
            }
        }

        /// <summary>
        /// Gets all staff and loads into a data transfer object with additional data
        /// </summary>
        /// <returns></returns>
        public async Task<List<GetStaffDTO>> GetStaffAsync()
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                var staff = await context.Staffs
                    .Where(i => i.Id != ModelConstants.Staff.SystemAdministrator)
                    .Include(i => i.Department)
                    .Include(i => i.JobTitle)
                    .ToListAsync();

                var dtos = staff.Select(i => new GetStaffDTO
                {
                    Id = i.Id,
                    StaffNumber = i.StaffNumber,
                    FullName = i.FullName,
                    NID = i.NID,
                    Department = i.Department.Name,
                    JobTitle = i.JobTitle.Name,
                    IsDepartmentHead = i.IsDepartmentHead,
                }).ToList();

                return dtos;
            }
        }


        /// <summary>
        /// Adds a new staff
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        public async Task<Core.Entities.Staff.Staff> AddAsync(AddEditStaffDTO createStaffDTO)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                var staff = createStaffDTO.Staff;
                context.Staffs.Add(staff);

                if (createStaffDTO.HasLogin)
                {
                    AddUser(createStaffDTO, staff.Id, context);
                }

                await context.SaveChangesAsync();

                return staff;
            }
        }

        /// <summary>
        /// Updates a given staff
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        public async Task<Core.Entities.Staff.Staff> UpdateAsync(AddEditStaffDTO editStaffDTO)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                var staff = editStaffDTO.Staff;

                if (editStaffDTO.HasLogin)
                {
                    //check if there is already a user associated with this staff
                    var user = await context.Users.FirstOrDefaultAsync(i => i.StaffId == staff.Id);

                    if (user != null)
                    {
                        user.UserName = editStaffDTO.Username;
                        user.NormalizedUserName = editStaffDTO.Username.ToUpper();
                        user.Email = editStaffDTO.Email;
                        user.NormalizedEmail = editStaffDTO.Email.ToUpper();

                        var hasher = new PasswordHasher<User>();
                        user.PasswordHash = hasher.HashPassword(user, editStaffDTO.Password);

                        context.Users.Update(user);

                        var adminRole = await context.UserRoles.FirstOrDefaultAsync(i => i.UserId == user.Id);
                        //check if user has admin access
                        if (editStaffDTO.HasAdminAccess && adminRole == null)
                        {
                            var userRole = new IdentityUserRole<string>
                            {
                                UserId = user.Id,
                                RoleId = InfrastructureConstants.Identity.RoleIds.Administrator
                            };

                            context.UserRoles.Add(userRole);
                        } else if (editStaffDTO.HasAdminAccess == false && adminRole != null)
                        {
                            context.UserRoles.Remove(adminRole);
                        }
                    }
                    else
                    {
                        AddUser(editStaffDTO, staff.Id, context);
                    }
                }

                context.Staffs.Update(staff);
                await context.SaveChangesAsync();

                return staff;
            }
        }

        /// <summary>
        /// Deletes a given staff
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Core.Entities.Staff.Staff> DeleteAsync(Guid id)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                var staff = await context.Staffs.FirstOrDefaultAsync(i => i.Id == id);
                context.Staffs.Remove(staff);
                await context.SaveChangesAsync();

                return staff;
            }
        }

        private void AddUser(AddEditStaffDTO addEditStaffDTO, Guid staffId, ApplicationDbContext context)
        {
            var user = new User
            {
                UserName = addEditStaffDTO.Username,
                NormalizedUserName = addEditStaffDTO.Username.ToUpper(),
                Email = addEditStaffDTO.Email,
                NormalizedEmail = addEditStaffDTO.Email.ToUpper(),
                EmailConfirmed = true,
                StaffId = staffId
            };

            var hasher = new PasswordHasher<User>();
            user.PasswordHash = hasher.HashPassword(user, addEditStaffDTO.Password);
            context.Users.Add(user);

            if (addEditStaffDTO.HasAdminAccess)
            {
                var userRole = new IdentityUserRole<string>
                {
                    UserId = user.Id,
                    RoleId = InfrastructureConstants.Identity.RoleIds.Administrator
                };

                context.UserRoles.Add(userRole);
            }
        }
    }
}

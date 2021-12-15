using AssetManager.Core;
using AssetManager.Core.DTO.Staff;
using AssetManager.Core.Entities.Staff;
using AssetManager.Core.Services.Staffs;
using AssetManager.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Services.Staff
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;

        public DepartmentService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Gets a department by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Department> GetByIdAsync(int id)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                return await context.Departments.FirstOrDefaultAsync(i => i.Id == id);
            }
        }

        /// <summary>
        /// Gets all departments
        /// </summary>
        /// <returns></returns>
        public async Task<List<Department>> GetAll()
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                return await context.Departments.Where(i => i.Id != ModelConstants.Departments.System).ToListAsync();
            }
        }

        /// <summary>
        /// Gets departments and feeds into a data transfer object with necessary data for viewing in the table.
        /// </summary>
        /// <returns></returns>
        public async Task<List<GetDepartmentsDTO>> GetDepartmentsTableAsync()
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                var departments = await context.Departments
                    .Where(i => i.Id != ModelConstants.Departments.System)
                    .Include(i => i.Staffs)
                    .ThenInclude(i => i.AssetHistories)
                    .Where(i => i.Staffs.All(s => s.AssetHistories.All(h => h.UnassignedDate == null))).ToListAsync();

                var dtos = departments.Select(i => new GetDepartmentsDTO
                {
                    Id = i.Id,
                    DepartmentName = i.Name,
                    DepartmentHead = i.Staffs.FirstOrDefault(i => i.IsDepartmentHead)?.FullName,
                    NumOfStaff = i.Staffs.Count(),
                });

                return dtos.ToList();
            }
        }

        /// <summary>
        /// Adds a new department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public async Task<Department> AddAsync(Department department)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Departments.Add(department);
                await context.SaveChangesAsync();
            }

            return department;
        }

        /// <summary>
        /// Updates a department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public async Task<Department> UpdateAsync(Department department)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Departments.Update(department);
                await context.SaveChangesAsync();
            }

            return department;
        }

        /// <summary>
        /// Deletes a department
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public async Task<Department> DeleteAsync(int departmentId)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                var department = await context.Departments.FirstOrDefaultAsync(i => i.Id == departmentId);
                context.Departments.Remove(department);
                await context.SaveChangesAsync();

                return department;
            }
        }
    }
}

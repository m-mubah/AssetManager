using AssetManager.Core.Entities.Asset;
using AssetManager.Core.Entities.Asset.Approval;
using AssetManager.Core.Entities.Staff;
using AssetManager.Infrastructure.Models.Identity;
using AssetManager.Infrastructure.SchemaConfiguration;
using AssetManager.Infrastructure.SchemaConfiguration.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Infrastructure.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Assets
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetHistory> AssetHistories { get; set; }
        public DbSet<AssetStatus> AssetStatuses { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<ApprovalChange> ApprovalChanges { get; set; }
        public DbSet<ApprovalStatus> ApprovalStatuses { get; set; }
        public DbSet<AssetApproval> AssetApprovals { get; set; }

        //Staffs
        public DbSet<Department> Departments { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AssetStatusSchemaConfiguration());
            builder.ApplyConfiguration(new AssetTypeSchemaConfiguration());
            builder.ApplyConfiguration(new ApprovalStatusSchemaConfiguration());

            //Identity
            builder.ApplyConfiguration(new RoleSchemaConfiguration());
            builder.ApplyConfiguration(new UserSchemaConfiguration());
            builder.ApplyConfiguration(new UserRoleSchemaConfiguration());

            //Staffs
            builder.ApplyConfiguration(new JobTitleSchemaConfiguration());
            builder.ApplyConfiguration(new DepartmentSchemaConfiguration());
            builder.ApplyConfiguration(new StaffSchemaConfiguration());
        }
    }
}

using AssetManager.Core;
using AssetManager.Core.Entities.Staff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Infrastructure.SchemaConfiguration
{
    public class StaffSchemaConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasData(
                new Staff
                {
                    Id = ModelConstants.Staff.SystemAdministrator,
                    FullName = "Administrator",
                    JobTitleId = ModelConstants.JobTitles.SystemAdministrator,
                    DepartmentId = ModelConstants.Departments.System,
                    UserId = InfrastructureConstants.Identity.DefaultUsers.Administrator
                }    
            );
        }
    }
}

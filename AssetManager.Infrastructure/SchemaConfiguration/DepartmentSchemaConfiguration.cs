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
    public class DepartmentSchemaConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                new Department
                {
                    Id = ModelConstants.Departments.System,
                    Name = "System"
                }
            );
        }
    }
}

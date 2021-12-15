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
    public class JobTitleSchemaConfiguration : IEntityTypeConfiguration<JobTitle>
    {
        public void Configure(EntityTypeBuilder<JobTitle> builder)
        {
            builder.HasData(
                new JobTitle
                {
                    Id = ModelConstants.JobTitles.SystemAdministrator,
                    Name = "System Administrator"
                }
            );
        }
    }
}

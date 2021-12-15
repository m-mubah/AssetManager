using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Infrastructure.SchemaConfiguration.Identity
{
    public class RoleSchemaConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = InfrastructureConstants.Identity.RoleIds.Administrator,
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR".ToUpper()
                }
            );
        }
    }
}

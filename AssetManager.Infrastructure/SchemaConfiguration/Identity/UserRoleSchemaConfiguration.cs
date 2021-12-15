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
    public class UserRoleSchemaConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                 new IdentityUserRole<string>
                 {
                     RoleId = InfrastructureConstants.Identity.RoleIds.Administrator,
                     UserId = InfrastructureConstants.Identity.DefaultUsers.Administrator
                 }
             );
        }
    }
}

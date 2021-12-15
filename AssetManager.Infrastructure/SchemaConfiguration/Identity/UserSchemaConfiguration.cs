using AssetManager.Core;
using AssetManager.Infrastructure.Models.Identity;
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
    public class UserSchemaConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           var user = new User
            {
                Id = InfrastructureConstants.Identity.DefaultUsers.Administrator,
                UserName = "administrator",
                NormalizedUserName = "ADMINISTRATOR".ToUpper(),
                Email = "administrator@localhost.com",
                NormalizedEmail = "ADMINISTRATOR@LOCALHOST.COM".ToUpper(),
                EmailConfirmed = true,
                StaffId = ModelConstants.Staff.SystemAdministrator
            };

            var hasher = new PasswordHasher<User>();
            user.PasswordHash = hasher.HashPassword(user, "Test@123");

            builder.HasData(
                user
            );
        }
    }
}

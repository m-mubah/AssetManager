using AssetManager.Core.Interfaces.Services;
using AssetManager.Infrastructure.Contexts;
using AssetManager.Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Services.Identity
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Gets the current user making the request.
        /// </summary>
        /// <returns>Current user</returns>
        public async Task<User> GetCurrentUserAsync()
        {
            var username = httpContextAccessor.HttpContext.User.Identity.Name;
            
            using (var context = dbContextFactory.CreateDbContext())
            {
                return await context.Users.FirstOrDefaultAsync(i => i.UserName == username);
            }
        }
    }
}

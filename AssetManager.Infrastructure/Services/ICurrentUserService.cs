using AssetManager.Infrastructure.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Interfaces.Services
{
    public interface ICurrentUserService
    {
        /// <summary>
        /// Gets the current user making the request.
        /// </summary>
        /// <returns>Current user</returns>
        Task<User> GetCurrentUserAsync();
    }
}

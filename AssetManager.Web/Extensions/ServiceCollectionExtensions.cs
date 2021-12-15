using AssetManager.Core.Interfaces.Services;
using AssetManager.Core.Services.Assets;
using AssetManager.Core.Services.Staffs;
using AssetManager.Web.Services.Assets;
using AssetManager.Web.Services.Identity;
using AssetManager.Web.Services.Staff;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IAssetService, AssetService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IJobTitleService, JobTitleService>();
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<IAssetApprovalService, AssetApprovalService>();
        }
    }
}

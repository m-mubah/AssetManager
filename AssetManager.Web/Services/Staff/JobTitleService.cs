using AssetManager.Core;
using AssetManager.Core.Entities.Staff;
using AssetManager.Core.Services.Staffs;
using AssetManager.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Services.Staff
{
    public class JobTitleService : IJobTitleService
    {
        private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;

        public JobTitleService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Gets a title by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<JobTitle> GetByIdAsync(int id)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                return await context.JobTitles.FirstOrDefaultAsync(i => i.Id == id);
            }
        }

        /// <summary>
        /// Gets all job titles
        /// </summary>
        /// <returns></returns>
        public async Task<List<JobTitle>> GetJobTitlesAsync()
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                return await context.JobTitles.Where(i => i.Id != ModelConstants.JobTitles.SystemAdministrator).ToListAsync();
            }
        }

        /// <summary>
        /// Adds a new job title
        /// </summary>
        /// <param name="jobTitle"></param>
        /// <returns></returns>
        public async Task<JobTitle> AddAsync(JobTitle jobTitle)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.JobTitles.Add(jobTitle);
                await context.SaveChangesAsync();
            }

            return jobTitle;
        }

        /// <summary>
        /// Updates a given job title.
        /// </summary>
        /// <param name="jobTitle"></param>
        /// <returns></returns>
        public async Task<JobTitle> UpdateAsync(JobTitle jobTitle)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                context.JobTitles.Update(jobTitle);
                await context.SaveChangesAsync();
            }

            return jobTitle;
        }

        /// <summary>
        /// Deletes a job title
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<JobTitle> DeleteAsync(int id)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                var jobTitle = await context.JobTitles.FirstOrDefaultAsync(i => i.Id == id);
                context.JobTitles.Remove(jobTitle);
                await context.SaveChangesAsync();

                return jobTitle;
            }
        }
    }
}

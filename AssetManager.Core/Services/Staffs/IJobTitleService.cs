using AssetManager.Core.Entities.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Services.Staffs
{
    public interface IJobTitleService
    {
        /// <summary>
        /// Gets a title by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<JobTitle> GetByIdAsync(int id);

        /// <summary>
        /// Gets all job titles
        /// </summary>
        /// <returns></returns>
        Task<List<JobTitle>> GetJobTitlesAsync();

        /// <summary>
        /// Adds a new job title
        /// </summary>
        /// <param name="jobTitle"></param>
        /// <returns></returns>
        Task<JobTitle> AddAsync(JobTitle jobTitle);

        /// <summary>
        /// Updates a given job title.
        /// </summary>
        /// <param name="jobTitle"></param>
        /// <returns></returns>
        Task<JobTitle> UpdateAsync(JobTitle jobTitle);

        /// <summary>
        /// Deletes a job title
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<JobTitle> DeleteAsync(int id);
    }
}

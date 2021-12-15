using AssetManager.Core.DTO.Staff;
using AssetManager.Core.Entities.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Services.Staffs
{
    public interface IDepartmentService
    {
        /// <summary>
        /// Gets a department by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Department> GetByIdAsync(int id);

        /// <summary>
        /// Gets all departments
        /// </summary>
        /// <returns></returns>
        Task<List<Department>> GetAll();

        /// <summary>
        /// Gets departments and feeds into a data transfer object with necessary data for viewing in the table.
        /// </summary>
        /// <returns></returns>
        Task<Department> AddAsync(Department department);

        /// <summary>
        /// Adds a new department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        Task<Department> UpdateAsync(Department department);

        /// <summary>
        /// Updates a department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        Task<List<GetDepartmentsDTO>> GetDepartmentsTableAsync();

        /// <summary>
        /// Deletes a department
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        Task<Department> DeleteAsync(int departmentId);
    }
}

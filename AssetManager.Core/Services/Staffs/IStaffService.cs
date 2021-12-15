using AssetManager.Core.DTO.Staff;
using AssetManager.Core.Entities.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Services.Staffs
{
    public interface IStaffService
    {
        /// <summary>
        /// Gets a staff by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AddEditStaffDTO> GetByIdAsync(Guid id);

        /// <summary>
        /// Gets all staff and loads into a data transfer object with additional data
        /// </summary>
        /// <returns></returns>
        Task<List<GetStaffDTO>> GetStaffAsync();

        /// <summary>
        /// Adds a new staff
        /// </summary>
        /// <param name="createStaffDTO"></param>
        /// <returns></returns>
        Task<Staff> AddAsync(AddEditStaffDTO createStaffDTO);

        /// <summary>
        /// Updates a given staff
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        Task<Staff> UpdateAsync(AddEditStaffDTO editStaffDTO);

        /// <summary>
        /// Deletes a given staff
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Staff> DeleteAsync(Guid id);

        /// <summary>
        /// Gets all staff
        /// </summary>
        /// <returns></returns>
        Task<IList<Staff>> GetAll();
    }
}

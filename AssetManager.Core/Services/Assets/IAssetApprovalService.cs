using AssetManager.Core.DTO.Asset;
using AssetManager.Core.Entities.Asset.Approval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Services.Assets
{
    public interface IAssetApprovalService
    {
        /// <summary>
        /// Creates an AssetApproval with the submitted changes
        /// </summary>
        /// <param name="editAssetDTO"></param>
        /// <returns>AssetApproval</returns>
        Task<AssetApproval> SendUpdatesForApproval(EditAssetDTO editAssetDTO);

        /// <summary>
        /// Gets all the approvals
        /// </summary>
        /// <param name="statusId">Filters by given status</param>
        /// <returns>List of asset approvals</returns>
        Task<IList<AssetApproval>> GetAll(int? statusId = null);

        /// <summary>
        /// Gets a single asset approval and creates a data transfer object with addtional details
        /// </summary>
        /// <param name="id">Id of approval</param>
        /// <returns></returns>
        Task<ViewAssetApprovalDTO> Get(Guid id);

        /// <summary>
        /// Changes approval status to rejected and updates asset status accordingly.
        /// </summary>
        /// <param name="id">Approval Id</param>
        /// <returns></returns>
        Task<AssetApproval> Reject(Guid id);

        /// <summary>
        /// Performs the approval process for the asset
        /// </summary>
        /// <param name="id">Approval Id</param>
        /// <returns></returns>
        Task<AssetApproval> Approve(Guid id);
    }
}

using AssetManager.Core;
using AssetManager.Core.DTO.Asset;
using AssetManager.Core.Entities.Asset;
using AssetManager.Core.Entities.Asset.Approval;
using AssetManager.Core.Interfaces.Services;
using AssetManager.Core.Services.Assets;
using AssetManager.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Services.Assets
{
    public class AssetApprovalService : IAssetApprovalService
    {
        private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;
        private readonly ICurrentUserService currentUserService;

        public AssetApprovalService(IDbContextFactory<ApplicationDbContext> dbContextFactory, ICurrentUserService currentUserService)
        {
            this.dbContextFactory = dbContextFactory;
            this.currentUserService = currentUserService;
        }

        /// <summary>
        /// Creates an AssetApproval with the submitted changes
        /// </summary>
        /// <param name="editAssetDTO"></param>
        /// <returns>AssetApproval</returns>
        public async Task<AssetApproval> SendUpdatesForApproval(EditAssetDTO editAssetDTO)
        {
            var requestedByUser = await currentUserService.GetCurrentUserAsync();

            using (var context = dbContextFactory.CreateDbContext())
            {
                var asset = await context.Assets.FirstOrDefaultAsync(i => i.Id == editAssetDTO.Asset.Id);

                var assetApproval = new AssetApproval
                {
                    Remarks = editAssetDTO.Remarks ?? "",
                    PreviousAssetStatus = asset.StatusId, //save current status of the asset
                    RequestedDate = DateTime.Now.Date,
                    StatusId = ModelConstants.ApprovalStatuses.Pending,
                    AssetId = asset.Id, 
                    RequestedByStaffId = requestedByUser.StaffId.Value,
                    ApprovalChange = new ApprovalChange
                    {
                        ReferenceNumber = String.IsNullOrEmpty(editAssetDTO.Asset.Reference) ? "" : editAssetDTO.Asset.Reference,
                        Name = String.IsNullOrEmpty(editAssetDTO.Asset.Name) ? "" : editAssetDTO.Asset.Name,
                        PurchasedDate = editAssetDTO.Asset.PurchasedDate ?? null,
                    }
                };

                //Checks if the asset is to be discarded
                if (editAssetDTO.Discarded)
                {
                    assetApproval.ApprovalChange.DiscardedDate = editAssetDTO.Asset.DiscardedDate;
                }

                //checks if the asset is to be assigned
                if (editAssetDTO.AssignedToStaff)
                {
                    assetApproval.ApprovalChange.LastAssignedDate = editAssetDTO.Asset.LastAssginedDate;
                    assetApproval.ApprovalChange.AssignedStaffId = editAssetDTO.AssetHistory.AssignedStaff.Id;
                }
                else if (asset.LastAssginedDate != null) //otherwise check if it is being unassigned
                {
                    var assetHistory = await context.AssetHistories.Include(i => i.AssignedStaff)
                        .Where(i => i.AssetId == asset.Id
                        && i.UnassignedDate == null)
                        .FirstOrDefaultAsync(i => i.AssignedDate.Date == asset.LastAssginedDate.Value.Date);

                    if (assetHistory != null) //an extra check to make sure there is something to unassign
                    {
                        assetApproval.ApprovalChange.UnassignedDate = DateTime.Now;
                    }
                }

                asset.StatusId = ModelConstants.AssetStatuses.ApprovalPending; //change status to approval pending

                context.AssetApprovals.Add(assetApproval);
                context.Assets.Update(asset);

                await context.SaveChangesAsync();

                return assetApproval;
            }
        }

        /// <summary>
        /// Gets all the approvals
        /// </summary>
        /// <param name="statusId">Filters by given status</param>
        /// <returns>List of asset approvals</returns>
        public async Task<IList<AssetApproval>> GetAll(int? statusId = null)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                var approvals = await context.AssetApprovals
                    .Include(i => i.Asset)
                    .Include(i => i.RequestedByStaff)
                    .Include(i => i.UpdatedByStaff)
                    .Include(i => i.Status)
                    .OrderByDescending(i => i.RequestedDate)
                    .ToListAsync();

                if (statusId != null)
                {
                    approvals = approvals.Where(i => i.StatusId == statusId).ToList();
                }

                return approvals;
            }
        }

        /// <summary>
        /// Gets a single asset approval and creates a data transfer object with addtional details
        /// </summary>
        /// <param name="id">Id of approval</param>
        /// <returns></returns>
        public async Task<ViewAssetApprovalDTO> Get(Guid id)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                var approval = await context.AssetApprovals
                    .Include(i => i.Asset).ThenInclude(i => i.Type)
                    .Include(i => i.RequestedByStaff)
                    .Include(i => i.UpdatedByStaff)
                    .Include(i => i.Status)
                    .Include(i => i.ApprovalChange)
                    .Include(i => i.ApprovalChange).ThenInclude(i => i.AssignedStaff)
                    .FirstOrDefaultAsync(i => i.Id == id);

                var assetApprovalDTO = new ViewAssetApprovalDTO
                {
                    AssetApproval = approval,
                    ApprovalChange = approval.ApprovalChange,
                };

                if (approval.ApprovalChange.DiscardedDate != null)
                {
                    assetApprovalDTO.Discarded = true;
                }

                if (approval.ApprovalChange.AssignedStaffId != null)
                {
                    assetApprovalDTO.AssignedToStaff = true;
                }

                return assetApprovalDTO;
            }
        }

        /// <summary>
        /// Changes approval status to rejected and updates asset status accordingly.
        /// </summary>
        /// <param name="id">Approval Id</param>
        /// <returns></returns>
        public async Task<AssetApproval> Reject(Guid id)
        {
            var updatedByUser = await currentUserService.GetCurrentUserAsync();

            using (var context = dbContextFactory.CreateDbContext())
            {
                var approval = await context.AssetApprovals.FirstOrDefaultAsync(i => i.Id == id);
                var asset = await context.Assets.FirstOrDefaultAsync(i => i.Id == approval.AssetId);

                //update approval status and log user
                approval.StatusId = ModelConstants.ApprovalStatuses.Rejected;
                approval.UpdatedDate = DateTime.Now;
                approval.UpdatedByStaffId = updatedByUser.StaffId.Value;

                //revert status of asset
                asset.StatusId = approval.PreviousAssetStatus;

                context.AssetApprovals.Update(approval);
                context.Assets.Update(asset);

                await context.SaveChangesAsync();

                return approval;
            }
        }

        /// <summary>
        /// Performs the approval process for the asset
        /// </summary>
        /// <param name="id">Approval Id</param>
        /// <returns></returns>
        public async Task<AssetApproval> Approve(Guid id)
        {
            var updatedByUser = await currentUserService.GetCurrentUserAsync();

            using (var context = dbContextFactory.CreateDbContext())
            {
                var approval = await context.AssetApprovals
                    .Include(i => i.Asset).ThenInclude(i => i.Type)
                    .Include(i => i.RequestedByStaff)
                    .Include(i => i.UpdatedByStaff)
                    .Include(i => i.Status)
                    .Include(i => i.ApprovalChange)
                    .Include(i => i.ApprovalChange).ThenInclude(i => i.AssignedStaff)
                    .FirstOrDefaultAsync(i => i.Id == id);

                var asset = await context.Assets.FirstOrDefaultAsync(i => i.Id == approval.AssetId);

                //check if it is to be discarded
                if (approval.ApprovalChange.DiscardedDate != null)
                {
                    asset.DiscardedDate = approval.ApprovalChange.DiscardedDate;
                    asset.StatusId = ModelConstants.AssetStatuses.Discarded;
                }

                //check if it is being assigned
                if (approval.ApprovalChange.AssignedStaffId != null)
                {
                    asset.LastAssginedDate = approval.ApprovalChange.LastAssignedDate;
                    asset.StatusId = ModelConstants.AssetStatuses.Assigned;

                    //create a new asset history
                    var assetHistory = new AssetHistory
                    {
                        AssetId = asset.Id,
                        AssignedStaffId = approval.ApprovalChange.AssignedStaffId.Value,
                        AssignedDate = approval.ApprovalChange.LastAssignedDate.Value
                    };

                    context.AssetHistories.Add(assetHistory);
                }
                else if (asset.LastAssginedDate != null) //otherwise check if it is being unassigned
                {
                    var assetHistory = await context.AssetHistories.Include(i => i.AssignedStaff)
                        .Where(i => i.AssetId == asset.Id
                        && i.UnassignedDate == null)
                        .FirstOrDefaultAsync(i => i.AssignedDate.Date == asset.LastAssginedDate.Value.Date);

                    if (assetHistory != null) //extra check to make sure there is something to be unassigned
                    {
                        assetHistory.UnassignedDate = approval.ApprovalChange.UnassignedDate;
                        asset.StatusId = ModelConstants.AssetStatuses.Unassigned;

                        context.AssetHistories.Update(assetHistory);
                    }
                } else
                {
                    asset.StatusId = approval.PreviousAssetStatus; //return to previous status
                }

                //merge changes
                asset.Name = approval.ApprovalChange.Name;
                asset.Reference = approval.ApprovalChange.ReferenceNumber;
                asset.PurchasedDate = approval.ApprovalChange.PurchasedDate;

                //update approval status and log update approved user
                approval.StatusId = ModelConstants.ApprovalStatuses.Approved;
                approval.UpdatedDate = DateTime.Now;
                approval.UpdatedByStaffId = updatedByUser.StaffId.Value;

                context.Assets.Update(asset);
                context.AssetApprovals.Update(approval);

                await context.SaveChangesAsync();

                return approval;
            }
        }
    }
}

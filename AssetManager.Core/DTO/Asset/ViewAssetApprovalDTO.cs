using AssetManager.Core.Entities.Asset.Approval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.DTO.Asset
{
    public class ViewAssetApprovalDTO
    {
        public AssetApproval AssetApproval { get; set; } = new AssetApproval();
        public ApprovalChange ApprovalChange { get; set; } = new ApprovalChange();

        public bool Discarded { get; set; } = false;
        public bool AssignedToStaff { get; set; } = false;
    }
}

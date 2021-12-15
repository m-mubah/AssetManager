using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Entities.Asset.Approval
{
    public class AssetApproval
    {
        public Guid Id { get; set; }
        public string Remarks { get; set; }
        public int PreviousAssetStatus { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int StatusId { get; set; }
        public virtual ApprovalStatus Status { get; set; }
        public Guid AssetId { get; set; }
        public virtual Asset Asset { get; set; }
        public Guid ApprovalChangeId { get; set; }
        public virtual ApprovalChange ApprovalChange { get; set; }
        public Guid RequestedByStaffId { get; set; }
        public virtual Staff.Staff RequestedByStaff { get; set; }
        public Guid? UpdatedByStaffId { get; set; }
        public virtual Staff.Staff UpdatedByStaff { get; set; }
    }
}

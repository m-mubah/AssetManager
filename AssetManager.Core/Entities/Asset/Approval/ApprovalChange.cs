using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Entities.Asset.Approval
{
    public class ApprovalChange
    {
        public Guid Id { get; set; }
        public string ReferenceNumber { get; set; }
        public string Name { get; set; }
        public DateTime? PurchasedDate { get; set; }
        public DateTime? DiscardedDate { get; set; }
        public DateTime? LastAssignedDate { get; set; }
        public DateTime? AssignedDate { get; set; }
        public DateTime? UnassignedDate { get; set; }
        public Guid? AssignedStaffId { get; set; }
        public virtual Staff.Staff AssignedStaff { get; set; }
    }
}

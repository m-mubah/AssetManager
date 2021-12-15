using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.DTO.Asset
{
    public class CreateAssetApprovalDTO
    {
        public Guid AssetId { get; set; }
        public Guid? StaffId { get; set; }
        public string ReferenceNumber { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public DateTime? PurchasedDate { get; set; }
        public DateTime? DiscardedDate { get; set; }
        public DateTime? LastAssignedDate { get; set; }
        public DateTime? AssignedDate { get; set; }
        public DateTime? UnassignedDate { get; set; }
    }
}

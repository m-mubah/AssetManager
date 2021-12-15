using AssetManager.Core.Entities.Asset.Approval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Entities.Asset
{
    public class Asset
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Reference { get; set; }
        public DateTime? PurchasedDate { get; set; }
        public DateTime? DiscardedDate { get; set; }
        public DateTime? LastAssginedDate { get; set; }

        public int StatusId { get; set; }
        public virtual AssetStatus Status { get; set; }
        public int TypeId { get; set; }
        public virtual AssetType Type { get; set; }

        public virtual IList<AssetApproval> AssetApprovals { get; set; }
        public virtual IList<AssetHistory> AssetHistories { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Entities.Asset
{
    public class AssetHistory
    {
        public int Id { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? UnassignedDate { get; set; }

        public Guid AssignedStaffId { get; set; }
        public virtual Staff.Staff AssignedStaff { get; set; }

        public Guid AssetId { get; set; }
        public virtual Asset Asset { get; set; }
    }
}

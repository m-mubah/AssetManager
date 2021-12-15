using AssetManager.Core.Entities.Asset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Entities.Staff
{
    public class Staff
    {
        public Guid Id { get; set; }
        public string StaffNumber { get; set; }
        public string NID { get; set; }
        public string FullName { get; set; }
        public string UserId { get; set; }
        public bool IsDepartmentHead { get; set; } = false;
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int JobTitleId { get; set; }
        public virtual JobTitle JobTitle { get; set; }
        public virtual IList<AssetHistory> AssetHistories { get; set; }
    }
}

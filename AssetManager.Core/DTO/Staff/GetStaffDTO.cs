using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.DTO.Staff
{
    public class GetStaffDTO
    {
        public Guid Id { get; set; }
        public string StaffNumber { get; set; }
        public string NID { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public bool IsDepartmentHead { get; set; }
    }
}

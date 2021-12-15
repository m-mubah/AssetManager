using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.DTO.Staff
{
    public class GetDepartmentsDTO
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentHead { get; set; }
        public int NumOfStaff { get; set; }
        public int NumOfAssignedAssets { get; set; }
    }
}

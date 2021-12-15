using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Entities.Staff
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Staff> Staffs { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.DTO.Staff
{
    public class AddEditStaffDTO
    {
        public Entities.Staff.Staff Staff { get; set; } = new();
        public bool HasLogin { get; set; } = false;
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool HasAdminAccess { get; set; }
    }
}

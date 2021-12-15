using AssetManager.Core.Entities.Staff;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Infrastructure.Models.Identity
{
    public class User : IdentityUser
    {
        public Guid? StaffId { get; set; }
        [ForeignKey(nameof(StaffId))]
        public virtual Staff Staff { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.DTO
{
    public class AddAssetDTO
    {
        public string Name { get; set; }
        public string Reference { get; set; }
        public int AssetTypeId { get; set; }
        public DateTime? PurchasedDate { get; set; } = DateTime.Today;
    }
}

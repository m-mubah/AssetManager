using AssetManager.Core.Entities.Asset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.DTO.Asset
{
    public class EditAssetDTO
    {
        public Entities.Asset.Asset Asset { get; set; } = new();
        public AssetHistory AssetHistory { get; set; } = null;
        public string Remarks { get; set; }
        public bool Discarded { get; set; } = false;
        public bool AssignedToStaff { get; set; } = false;
    }
}

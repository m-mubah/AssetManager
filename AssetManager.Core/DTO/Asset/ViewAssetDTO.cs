using AssetManager.Core.Entities.Asset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.DTO.Asset
{
    public class ViewAssetDTO
    {
        public Entities.Asset.Asset Asset { get; set; }
        public AssetHistory  AssetHistory { get; set; }
    }
}

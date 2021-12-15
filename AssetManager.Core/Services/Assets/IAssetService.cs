using AssetManager.Core.DTO;
using AssetManager.Core.DTO.Asset;
using AssetManager.Core.Entities.Asset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Services.Assets
{
    public interface IAssetService
    {
        /// <summary>
        /// Returns all assets after ordering by purchased date.
        /// </summary>
        /// <returns></returns>
        Task<IList<ViewAssetDTO>> GetAssetsAsync();

        /// <summary>
        /// Adds a new asset to database
        /// </summary>
        /// <param name="addAssetDTO">Data to be added</param>
        /// <returns>New asset</returns>
        Task<Asset> AddAssetAsync(AddAssetDTO addAssetDTO);

        Task<EditAssetDTO> GetAssetAsync(Guid id);

        /// <summary>
        /// Generates an asset number based on current date and number of assets added on that day.
        /// For the first asset generated on 12 october 2021, it will be 20211012001 in the format YYYYMMDDNNNN.
        /// Where NNN referes to the number of assets on that day plus one.
        /// This is converted to a hexadecimal string and can be used as a reference for an asset.
        /// </summary>
        /// <returns>Hexadecimal reference string</returns>
        Task<string> GenerateAssetNumberAsync();

        /// <summary>
        /// Get all asset types
        /// </summary>
        /// <returns></returns>
        Task<IList<AssetType>> GetAllTypes();
    }
}

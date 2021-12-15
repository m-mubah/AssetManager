using AssetManager.Core;
using AssetManager.Core.DTO;
using AssetManager.Core.DTO.Asset;
using AssetManager.Core.Entities.Asset;
using AssetManager.Core.Entities.Asset.Approval;
using AssetManager.Core.Interfaces.Services;
using AssetManager.Core.Services.Assets;
using AssetManager.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Services.Assets
{
    public class AssetService : IAssetService
    {
        private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;
        private readonly ICurrentUserService currentUserService;

        public AssetService(IDbContextFactory<ApplicationDbContext> dbContextFactory, ICurrentUserService currentUserService)
        {
            this.dbContextFactory = dbContextFactory;
            this.currentUserService = currentUserService;
        }

        /// <summary>
        /// Gets all assets
        /// </summary>
        /// <returns></returns>
        public async Task<IList<ViewAssetDTO>> GetAssetsAsync()
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                var assets = await context.Assets
                    .Include(i => i.Status)
                    .Include(i => i.Type)
                    .OrderByDescending(i => i.PurchasedDate)
                    .ThenBy(i => i.Id)
                    .ToListAsync();

                var viewAssetsList = new List<ViewAssetDTO>();

                foreach(var asset in assets)
                {
                    var viewAssetDTO = new ViewAssetDTO
                    {
                        Asset = asset,
                        AssetHistory = null
                    };

                    if (asset.LastAssginedDate != null)
                    {
                        var assetHistory = await context.AssetHistories.Include(i => i.AssignedStaff)
                            .Where(i => i.AssetId == asset.Id
                            && i.UnassignedDate == null)
                            .FirstOrDefaultAsync(i => i.AssignedDate.Date == asset.LastAssginedDate.Value.Date);

                        viewAssetDTO.AssetHistory = assetHistory;
                    }

                    viewAssetsList.Add(viewAssetDTO);
                }

                return viewAssetsList;
            }
        }

        /// <summary>
        /// Gets a single asset and loads into a data transfer object with additional data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<EditAssetDTO> GetAssetAsync(Guid id)
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                var asset = await context.Assets
                    .Include(i => i.Status)
                    .Include(i => i.Type)
                    .FirstOrDefaultAsync(i => i.Id == id);

                var editAssetDTO = new EditAssetDTO();
                editAssetDTO.Asset = asset;

                //if the asset was assigned load the latest asset history with the assigned staff
                if (asset.LastAssginedDate != null)
                {
                    var assetHistory = await context.AssetHistories.Include(i => i.AssignedStaff)
                        .Where(i => i.AssetId == id
                        && i.UnassignedDate == null)
                        .FirstOrDefaultAsync(i => i.AssignedDate.Date == asset.LastAssginedDate.Value.Date);

                    editAssetDTO.AssetHistory = assetHistory;
                    editAssetDTO.AssignedToStaff = true;
                }

                if (asset.DiscardedDate != null)
                {
                    editAssetDTO.Discarded = true;
                }

                return editAssetDTO;
            }
        }

        /// <summary>
        /// Adds a new asset
        /// </summary>
        /// <param name="addAssetDTO"></param>
        /// <returns></returns>
        public async Task<Asset> AddAssetAsync(AddAssetDTO addAssetDTO)
        {
            var asset = new Asset
            {
                Name = addAssetDTO.Name,
                Reference = addAssetDTO.Reference,
                PurchasedDate = addAssetDTO.PurchasedDate.Value,
                TypeId = addAssetDTO.AssetTypeId,
                StatusId = ModelConstants.AssetStatuses.New
            };

            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Assets.Add(asset);
                await context.SaveChangesAsync();
            }

            return asset;
        }

        /// <summary>
        /// Generates an asset number based on current date and number of assets added on that day.
        /// For the first asset generated on 12 october 2021, it will be 20211012001 in the format YYYYMMDDNNNN.
        /// Where NNN referes to the number of assets on that day plus one.
        /// This is converted to a hexadecimal string and can be used as a reference for an asset.
        /// </summary>
        /// <returns>Hexadecimal reference string</returns>
        public async Task<string> GenerateAssetNumberAsync()
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                var date = DateTime.Today;
                var year = date.Year;
                var month = date.Month;
                var day = date.Day;

                int count = await context.Assets.Where(b => b.PurchasedDate.Value.Date == date).CountAsync();
                count = count + 1;


                var code = Int32.Parse(year.ToString().Substring(Math.Max(0, year.ToString().Length - 4)) + month.ToString() + day.ToString() + count);
                var assetNumber = code.ToString("X");

                return assetNumber;
            }
        }

        /// <summary>
        /// Get all asset types
        /// </summary>
        /// <returns></returns>
        public async Task<IList<AssetType>> GetAllTypes()
        {
            using (var context = dbContextFactory.CreateDbContext())
            {
                return await context.AssetTypes.ToListAsync();
            }
        }
    }
}

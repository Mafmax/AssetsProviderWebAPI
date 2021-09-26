using AutoMapper;
using Mafmax.AssetsProvider.BLL.DTOs;
using Mafmax.AssetsProvider.DAL.Context;
using Mafmax.AssetsProvider.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Mafmax.AssetsProvider.BLL.Services
{
    /// <summary>
    /// Processes assets data
    /// </summary>
    public class AssetsService : AssetsProviderService, IAssetsService
    {
        /// <summary>
        /// Creates service
        /// </summary>
        /// <param name="db"></param>
        /// <param name="mapper"></param>
        public AssetsService(APContext db, IMapper mapper) : base(db, mapper)
        {
        }


        /// <summary>
        /// Finds assets by regex pattern by fields e.g. Name, Ticker or ISIN
        /// </summary>
        /// <param name="searchPattern">Pattern to match</param>
        /// <returns></returns>
        public async Task<IEnumerable<Asset>> FindAssetsAsync(string searchPattern)
        {
            Regex regex = new(searchPattern);
            
            bool searchPredicate(Asset x) =>
                regex.IsMatch(x.Name) || regex.IsMatch(x.Ticker) || regex.IsMatch(x.ISIN);

            return await Task.Run(() => db.Assets.Where(searchPredicate));
        }

#pragma warning disable CS1591
        #region IAssetsProviderService
        public async Task<Dictionary<string, IEnumerable<ShortAssetDto>>> FindAssetsAsync(string searchValue, string assetClass = null)
        {
            bool classFilterPredicate(Asset x) =>
            string.IsNullOrEmpty(assetClass) || x.Class.Equals(assetClass);

            var foundAssets = await FindAssetsAsync(searchValue);
            return foundAssets
                .Where(classFilterPredicate)
                .GroupBy(x => x.Class)
                .ToDictionary(x => x.Key, x => x.Select(y => mapper.Map<ShortAssetDto>(y)));

        }

        public async Task<AssetDto> GetAssetByIdAsync(int assetId)
        {
            Asset asset = await db.Assets.FindAsync(assetId);
            return mapper.Map<AssetDto>(asset);
        }


        public async Task<AssetDto> GetAssetByISINAsync(string assetISIN)
        {
            Task<Asset> assetTask = Task.Run(() =>
            {
                return db.Assets.FirstOrDefault(x => x.ISIN.Equals(assetISIN, StringComparison.OrdinalIgnoreCase));
            });

            Asset asset = await assetTask;

            return mapper.Map<AssetDto>(asset);

        }




        #endregion
#pragma warning restore CS1591


    }
}

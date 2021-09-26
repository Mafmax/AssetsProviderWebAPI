using AutoMapper;
using Mafmax.AssetsProvider.BLL.DTOs;
using Mafmax.AssetsProvider.DAL.Context;
using Mafmax.AssetsProvider.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        public AssetsService(AssetsProviderContext db, IMapper mapper) : base(db, mapper)
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
            var assets = await db.Assets.ToListAsync();
            return assets.Where(searchPredicate);
        }

        private IQueryable<Asset> FullAssetWithIncludes => db.Assets
               .Include(x => x.Stock)
               .Include(x => x.Issuer).ThenInclude(x => x.Country)
               .Include(x => x.Issuer).ThenInclude(x => x.Industry);

        #region IAssetsProviderService
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="searchValue"></param>
        /// <param name="assetClass"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, IEnumerable<ShortAssetDto>>> FindAssetsAsync(string searchValue, string assetClass = null)
        {
            bool classFilterPredicate(Asset x) =>
            string.IsNullOrEmpty(assetClass) || x.Class.Equals(assetClass);

            var foundAssetsIds = (await FindAssetsAsync(searchValue)).Select(x => x.Id);
            return FullAssetWithIncludes
                .Where(x => foundAssetsIds.Contains(x.Id))
                .Where(classFilterPredicate)
                .GroupBy(x => x.Class)
                .ToDictionary(x => x.Key, x => x.Select(y => mapper.Map<ShortAssetDto>(y)));

        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        public async Task<AssetDto> GetByIdAsync(int assetId)
        {
            Asset asset = await FullAssetWithIncludes
                .FirstOrDefaultAsync(x => x.Id.Equals(assetId));

            return mapper.Map<AssetDto>(asset);
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="assetISIN"></param>
        /// <returns></returns>
        public async Task<AssetDto> GetByISINAsync(string assetISIN)
        {
            Asset asset = await FullAssetWithIncludes.FirstOrDefaultAsync(x => x.ISIN == assetISIN);
            return mapper.Map<AssetDto>(asset);
        }
        #endregion


    }
}

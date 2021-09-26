using Mafmax.AssetsProvider.BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mafmax.AssetsProvider.BLL.Services
{
    /// <summary>
    /// Defines methods to work with assets 
    /// </summary>
    public interface IAssetsService
    {

        /// <summary>
        /// Finds asset with id
        /// </summary>
        /// <param name="assetId">Identifier to find</param>
        /// <returns></returns>
        Task<AssetDto> GetByIdAsync(int assetId);

        /// <summary>
        /// Finds asset with isin
        /// </summary>
        /// <param name="assetISIN">Identifier to find</param>
        /// <returns></returns>
        Task<AssetDto> GetByISINAsync(string assetISIN);

        /// <summary>
        /// Finds asset by value. Value may be part of isin, name or ticker
        /// </summary>
        /// <param name="searchValue">Search query</param>
        /// <param name="assetClass">Class filter</param>
        /// <returns></returns>
        Task<Dictionary<string, IEnumerable<ShortAssetDto>>> FindAssetsAsync(string searchValue, string assetClass = null);

    }
}

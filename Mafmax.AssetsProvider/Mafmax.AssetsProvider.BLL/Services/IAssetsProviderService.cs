using Mafmax.AssetsProvider.BLL.DTOs;
using Mafmax.AssetsProvider.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mafmax.AssetsProvider.BLL.Services
{
    /// <summary>
    /// Defines methods to work with assets provider
    /// </summary>
    public interface IAssetsProviderService
    {

        /// <summary>
        /// Gets all issuers from storage
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IssuerDto>> GetIssuersAsync();

        /// <summary>
        /// Gets all issuer assets by id
        /// </summary>
        /// <param name="issuerId">Issuer identifier</param>
        /// <returns></returns>
        Task<IEnumerable<ShortAssetDto>> GetAssetsByIssuerAsync(int issuerId);

        /// <summary>
        /// Finds asset with id
        /// </summary>
        /// <param name="assetId">Identifier to find</param>
        /// <returns></returns>
        Task<AssetDto> GetAssetByIdAsync(int assetId);

        /// <summary>
        /// Finds asset with isin
        /// </summary>
        /// <param name="assetISIN">Identifier to find</param>
        /// <returns></returns>
        Task<AssetDto> GetAssetByISINAsync(string assetISIN);

        /// <summary>
        /// Finds asset by value. Value may be part of isin, name or ticker
        /// </summary>
        /// <param name="searchValue">Search query</param>
        /// <param name="assetClass">Class filter</param>
        /// <returns></returns>
        Task<Dictionary<string, IEnumerable<ShortAssetDto>>> FindAssetsAsync(string searchValue, string assetClass = null);

    }
}

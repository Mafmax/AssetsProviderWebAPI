using Mafmax.AssetsProvider.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mafmax.AssetsProvider.BLL.Services
{
    /// <summary>
    /// Defines methods to work with issuers
    /// </summary>
    public interface IIssuersService
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
    }
}

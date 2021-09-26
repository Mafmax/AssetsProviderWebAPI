using Mafmax.AssetsProvider.BLL.DTOs;
using System.Collections.Generic;
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
        /// <exception cref="KeyNotFoundException">Throws if issuer company not found</exception>
        Task<IEnumerable<ShortAssetDto>> GetAssetsAsync(int issuerId);



    }
}

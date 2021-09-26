using AutoMapper;
using Mafmax.AssetsProvider.BLL.DTOs;
using Mafmax.AssetsProvider.DAL.Context;
using Mafmax.AssetsProvider.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mafmax.AssetsProvider.BLL.Services
{
    /// <summary>
    /// Processes issuers data
    /// </summary>
    public class IssuersService : AssetsProviderService, IIssuersService
    {
        /// <summary>
        /// Creates service
        /// </summary>
        /// <param name="db"></param>
        /// <param name="mapper"></param>
        public IssuersService(AssetsProviderContext db, IMapper mapper) : base(db, mapper)
        {
        }

        #region IIssuersService
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="issuerId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ShortAssetDto>> GetAssetsAsync(int issuerId)
        {
            var issuer = await db.Issuers.FindAsync(issuerId);
            if (issuer is null) throw new KeyNotFoundException($"Issuer with id {issuerId} not found");
            var assets = await db.Assets
            .Include(x => x.Stock)
            .Where(x => x.IssuerId == issuerId)
            .ToListAsync();
            return assets
            .OrderBy(x => x.Circulation.Start.Ticks)
            .Select(x => mapper.Map<ShortAssetDto>(x));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IssuerDto>> GetIssuersAsync()
        {
            var issuers = await db.Issuers
                .Include(x => x.Country)
                .Include(x => x.Industry)
                .ToListAsync();
            return issuers.Select(x => mapper.Map<IssuerDto>(x));
        }
        #endregion
    }
}

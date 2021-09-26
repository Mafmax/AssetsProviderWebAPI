using AutoMapper;
using Mafmax.AssetsProvider.BLL.DTOs;
using Mafmax.AssetsProvider.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public IssuersService(APContext db, IMapper mapper) : base(db, mapper)
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
            return await Task.Run(() =>
            db.Assets
            .Include(x=>x.Stock)
            .Where(x => x.IssuerId == issuerId)
            .AsEnumerable()
            .OrderBy(x => x.Circulation.Start.Ticks)
            .Select(x => mapper.Map<ShortAssetDto>(x))
            );
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IssuerDto>> GetIssuersAsync()
        {
            return await Task.Run(() =>
            {
                return db.Issuers
                .Include(x=>x.Country)
                .Include(x=>x.Industry)
                .Select(x => mapper.Map<IssuerDto>(x));
            });
        }
        #endregion
    }
}

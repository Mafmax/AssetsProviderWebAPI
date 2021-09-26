using AutoMapper;
using Mafmax.AssetsProvider.BLL.DTOs;
using Mafmax.AssetsProvider.DAL.Context;
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
#pragma warning disable CS1591
        public async Task<IEnumerable<ShortAssetDto>> GetAssetsByIssuerAsync(int issuerId)
        {
            return await Task.Run(() =>
            db.Assets.Where(x => x.Issuer.Id.Equals(issuerId) && x.Circulation.IsInCirculation)
            .OrderBy(x => x.Circulation.Start.Ticks)
            .Select(x => mapper.Map<ShortAssetDto>(x))
            );
        }

        public async Task<IEnumerable<IssuerDto>> GetIssuersAsync()
        {
            return await Task.Run(() =>
            {
                return db.Issuers.Select(x => mapper.Map<IssuerDto>(x));
            });
        }
#pragma warning restore CS1591
        #endregion
    }
}

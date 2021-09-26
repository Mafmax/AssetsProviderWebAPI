using AutoMapper;
using Mafmax.AssetsProvider.DAL.Context;

namespace Mafmax.AssetsProvider.BLL.Services
{
    /// <summary>
    /// Base class for all AssetsProvider services
    /// </summary>
    public abstract class AssetsProviderService 
    {
        /// <summary>
        /// Database context
        /// </summary>
        protected readonly AssetsProviderContext db;

        /// <summary>
        /// AutoMapper object
        /// </summary>
        protected readonly IMapper mapper;

        /// <summary>
        /// Creates service
        /// </summary>
        /// <param name="db">Database context</param>
        /// <param name="mapper">AutoMapper</param>
        public AssetsProviderService(AssetsProviderContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
    }
}

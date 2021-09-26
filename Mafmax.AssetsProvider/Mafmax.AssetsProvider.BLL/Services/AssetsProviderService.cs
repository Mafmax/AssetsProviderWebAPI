using AutoMapper;
using Mafmax.AssetsProvider.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        protected readonly APContext db;

        /// <summary>
        /// AutoMapper object
        /// </summary>
        protected readonly IMapper mapper;

        /// <summary>
        /// Creates service
        /// </summary>
        /// <param name="db">Database context</param>
        /// <param name="mapper">AutoMapper</param>
        public AssetsProviderService(APContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
    }
}

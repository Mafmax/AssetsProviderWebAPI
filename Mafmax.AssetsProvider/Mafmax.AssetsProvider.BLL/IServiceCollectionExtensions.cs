using Mafmax.AssetsProvider.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mafmax.AssetsProvider.BLL
{
    /// <summary>
    /// Extension methods for IServiceCollection
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds DbContext
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        public static void AddCustomDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AssetsProviderContext>(opt => opt.UseSqlServer(connectionString, 
                x => x.MigrationsAssembly("Mafmax.AssetsProvider.DAL.Migrations")));
        }
    }
}

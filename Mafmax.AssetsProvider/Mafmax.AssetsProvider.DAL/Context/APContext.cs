using Mafmax.AssetsProvider.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mafmax.AssetsProvider.DAL.Context
{
    /// <summary>
    /// Database context for Assets Provider application
    /// </summary>
    public class APContext : DbContext
    {
        /// <summary>
        /// Create APContext
        /// </summary>
        /// <param name="options">Context creating options</param>
        public APContext(DbContextOptions<APContext> options) : base(options)
        {

        }

        /// <summary>
        /// All assets
        /// </summary>
        public DbSet<Asset> Assets { get; set; }

        /// <summary>
        /// Shares (stocks). Specific assets.
        /// </summary>
        public DbSet<Share> Shares { get; set; }

        /// <summary>
        /// Bonds. Specific assets.
        /// </summary>
        public DbSet<Bond> Bonds { get; set; }

        /// <summary>
        /// Countries e.g. USA or Russia
        /// </summary>
        public DbSet<Country> Countries { get; set; }


        /// <summary>
        /// Companies which issue assets
        /// </summary>
        public DbSet<Issuer> Issuers { get; set; }

        /// <summary>
        /// Industries of business
        /// </summary>

        public DbSet<Industry> Industries { get; set; }



    }
}

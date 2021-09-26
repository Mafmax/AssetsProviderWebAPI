using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mafmax.AssetsProvider.DAL.Entities
{
    /// <summary>
    /// Base type for assets
    /// </summary>
    [Table("Assets")]
    public abstract class Asset
    {
        /// <summary>
        /// Unique key for asset
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Alphabetic asset identifier
        /// </summary>
        [Required]
        public string Ticker { get; set; }

        /// <summary>
        /// International Securities Identification Number
        /// </summary>
        [Required]
        public string ISIN { get; set; }

        /// <summary>
        /// Asset name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// FK for Issuer
        /// </summary>
        public int IssuerId { get; set; }

        /// <summary>
        /// Assets issuer company
        /// </summary>
        public Issuer Issuer { get; set; }

        /// <summary>
        /// FK for Stock
        /// </summary>
        public int StockId { get; set; }

        /// <summary>
        /// Stock exchange organization
        /// </summary>
        public StockExchange Stock { get; set; }

        /// <summary>
        /// Period of assets circulation
        /// </summary>
        public CirculationPeriod Circulation { get; set; }


        /// <summary>
        /// Currency name e.g. USD, RUB
        /// </summary>
        [Column("BaseCurrency")]
        public string Currency { get; set; }

        /// <summary>
        /// Number of assets in one lot 
        /// </summary>
        public int LotSize { get; set; }

        /// <summary>
        /// Asset class e.g. share or bond
        /// </summary>
        [NotMapped]
        public abstract string Class { get; }

    }
}

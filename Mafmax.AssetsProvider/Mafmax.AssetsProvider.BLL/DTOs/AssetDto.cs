using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mafmax.AssetsProvider.BLL.DTOs
{
    /// <summary>
    /// Full information asset data transfer object
    /// </summary>
    public class AssetDto
    {
        /// <summary>
        /// Unique key for asset
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Alphabetic asset identifier
        /// </summary>
        public string Ticker { get; set; }

        /// <summary>
        /// International Securities Identification Number
        /// </summary>
        public string ISIN { get; set; }

        /// <summary>
        /// Asset name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Assets issuer company name
        /// </summary>
        public IssuerDto Issuer { get; set; }


        /// <summary>
        /// Stock exchange organization
        /// </summary>
        public StockExchangeDto Stock { get; set; }

        /// <summary>
        /// Period of assets circulation
        /// </summary>
        public CirculationPeriodDto Circulation { get; set; }


        /// <summary>
        /// Currency name e.g. USD, RUB
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Number of assets in one lot 
        /// </summary>
        public int LotSize { get; set; }

        /// <summary>
        /// Asset class e.g. share or bond
        /// </summary>
        public string Class { get; set; }
    }
}

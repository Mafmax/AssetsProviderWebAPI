using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mafmax.AssetsProvider.BLL.DTOs
{
    /// <summary>
    /// Short information about asset
    /// </summary>
    public class ShortAssetDto
    {

        
        /// <summary>
        /// Asset identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Asset name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Asset class
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// Asset ISIN
        /// </summary>
        public string ISIN { get; set; }

        /// <summary>
        /// Asset ticker
        /// </summary>
        public string Ticker { get; set; }

        /// <summary>
        /// Asset exchange stock code
        /// </summary>
        public string ExchangeStockCode { get; set; }

        /// <summary>
        /// Asset issuer name
        /// </summary>
        public string IssuerName { get; set; }


    }
}

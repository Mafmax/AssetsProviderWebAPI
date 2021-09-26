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
    /// Stock exchange entity
    /// </summary>
    public class StockExchange
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [Key]
        public int Id{ get; set; }

        /// <summary>
        /// Stock exchange key e.g. MOEX
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Stock exchange name
        /// </summary>
        public string Name { get; set; }
    }
}

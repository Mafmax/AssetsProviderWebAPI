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
    /// Issuer entity
    /// </summary>
    public class Issuer
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Company name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Company country
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Company industry
        /// </summary>
        public Industry Industry { get; set; }

    }
}

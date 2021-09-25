using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mafmax.AssetsProvider.DAL.Entities
{
    /// <summary>
    /// Company industry
    /// </summary>
    public class Industry
    {
        /// <summary>
        /// Industry identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Industry name
        /// </summary>
        public string Name { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mafmax.AssetsProvider.BLL.DTOs
{
    /// <summary>
    /// Issuer company data transfer object
    /// </summary>
    public class IssuerDto
    {
        /// <summary>
        /// Issuer name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Issuer country name
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Issuer industry name
        /// </summary>
        public string Industry { get; set; }
    }
}

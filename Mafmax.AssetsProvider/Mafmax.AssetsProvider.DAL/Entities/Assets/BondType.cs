using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mafmax.AssetsProvider.DAL.Entities
{
    /// <summary>
    /// Type of bond
    /// </summary>
    public enum BondType
    {
        /// <summary>
        /// Issued by a national goverment. Other name is sovereign.
        /// </summary>
        Government,

        /// <summary>
        /// Issued by a state, municipality or country.
        /// </summary>
        Municipal,

        /// <summary>
        /// Issued by a firm
        /// </summary>
        Corporate
    }
}

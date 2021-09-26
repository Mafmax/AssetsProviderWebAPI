using System.ComponentModel.DataAnnotations.Schema;

namespace Mafmax.AssetsProvider.DAL.Entities
{
    /// <summary>
    /// Bond entity
    /// </summary>
    public class Bond : Asset
    {
        /// <summary>
        /// Type of bond.
        /// </summary>
        public BondType Type { get; set; }

        /// <summary>
        /// Asset class
        /// </summary>
        [NotMapped]
        public override string Class => "Bond";
    }
}

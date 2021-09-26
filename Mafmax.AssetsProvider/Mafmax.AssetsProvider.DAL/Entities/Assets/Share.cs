using System.ComponentModel.DataAnnotations.Schema;

namespace Mafmax.AssetsProvider.DAL.Entities
{
    /// <summary>
    /// Share (stock) entity
    /// </summary>
    public class Share : Asset
    {
        /// <summary>
        /// Flag of preffered or common share
        /// </summary>
        public bool IsPreffered { get; set; }

        /// <summary>
        /// Asset class
        /// </summary>
        [NotMapped]
        public override string Class => "Share";
    }
}

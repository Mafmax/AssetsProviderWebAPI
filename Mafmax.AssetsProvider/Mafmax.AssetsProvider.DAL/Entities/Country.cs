using System.ComponentModel.DataAnnotations;

namespace Mafmax.AssetsProvider.DAL.Entities
{
    /// <summary>
    /// Country entity
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        public string Name { get; set; }
    }
}

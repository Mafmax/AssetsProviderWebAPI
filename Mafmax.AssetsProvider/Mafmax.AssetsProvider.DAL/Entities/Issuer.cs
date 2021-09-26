using System.ComponentModel.DataAnnotations;

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
        /// FK for Country 
        /// </summary>
        public int CountryId { get; set; }
        
        /// <summary>
        /// Company country
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// FK for Industry
        /// </summary>
        public int IndustryId { get; set; }

        /// <summary>
        /// Company industry
        /// </summary>
        public Industry Industry { get; set; }

    }
}

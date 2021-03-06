using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mafmax.AssetsProvider.DAL.Entities
{
    /// <summary>
    /// Period of asset circulation
    /// </summary>
    [Owned]
    public class CirculationPeriod
    {
        /// <summary>
        /// Start date of circulation
        /// </summary>
        [Column("StartCirculation")]
        [Required]
        public DateTime Start { get; set; }

        /// <summary>
        /// End date of circulation
        /// </summary>
        [Column("EndCirculation")]
        public DateTime? End { get; set; }

        /// <summary>
        /// Flag of the asset in circulation
        /// </summary>
        [NotMapped]
        public bool IsInCirculation => !End.HasValue;
    }
}

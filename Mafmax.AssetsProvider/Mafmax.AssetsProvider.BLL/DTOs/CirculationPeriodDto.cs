using System;

namespace Mafmax.AssetsProvider.BLL.DTOs
{
    /// <summary>
    /// DTO for circulation period of asset 
    /// </summary>
    public class CirculationPeriodDto
    {
        /// <summary>
        /// Start date of circulation
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// End date of circulation
        /// </summary>
        public DateTime? End { get; set; }
    }
}

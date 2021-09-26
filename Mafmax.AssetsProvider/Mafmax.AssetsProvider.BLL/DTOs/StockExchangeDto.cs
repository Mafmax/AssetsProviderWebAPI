namespace Mafmax.AssetsProvider.BLL.DTOs
{
    /// <summary>
    /// Data transfer object for Stock exchange entity
    /// </summary>
    public class StockExchangeDto
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Stock exchange key e.g. MOEX
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Stock exchange name
        /// </summary>
        public string Name { get; set; }
    }
}

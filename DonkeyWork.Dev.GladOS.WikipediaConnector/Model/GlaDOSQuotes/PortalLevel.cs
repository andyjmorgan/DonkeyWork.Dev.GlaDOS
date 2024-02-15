namespace DonkeyWork.Dev.GladOS.WikipediaConnector.Model.GladOSQuotes
{
    /// <summary>
    /// GlaDOS audio lines, sorted by Level.
    /// </summary>
    public class PortalLevel
    {
        /// <summary>
        /// The name of the level.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// A list of Quotes from GlaDOS in this level.
        /// </summary>
        public List<GlaDOSQuote> Quotes { get; set; } = new();

    }
}

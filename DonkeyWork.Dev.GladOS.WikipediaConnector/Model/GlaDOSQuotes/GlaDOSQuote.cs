namespace DonkeyWork.Dev.GladOS.WikipediaConnector.Model.GladOSQuotes
{
    /// <summary>
    /// A GladOS Voice Line.
    /// </summary>
    public class GlaDOSQuote
    {
        /// <summary>
        /// The voice line text.
        /// </summary>
        public string? QuoteText { get; set; }

        /// <summary>
        /// A link to the recording.
        /// </summary>
        public Uri? AudioFile { get; set; }
    }
}

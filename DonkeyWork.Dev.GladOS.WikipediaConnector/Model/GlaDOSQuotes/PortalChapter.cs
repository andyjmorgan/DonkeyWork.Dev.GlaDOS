namespace DonkeyWork.Dev.GladOS.WikipediaConnector.Model.GladOSQuotes
{
    /// <summary>
    /// A Portal Chapter, containing the audio lines and text, sorted by level.
    /// </summary>
    public class PortalChapter
    {
        /// <summary>
        /// The Name of the chapter
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// A List of <see cref="PortalLevel"/> containing the audio lines.
        /// </summary>
        public List<PortalLevel> Levels { get; set; } = new();
    }
}

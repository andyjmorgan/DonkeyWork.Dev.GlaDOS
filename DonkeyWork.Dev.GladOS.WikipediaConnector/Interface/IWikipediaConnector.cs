using DonkeyWork.Dev.GladOS.WikipediaConnector.Model.GladOSQuotes;

namespace DonkeyWork.Dev.GladOS.WikipediaConnector.Interface
{
    public interface IWikipediaConnector
    {
        /// <summary>
        /// Retrieves a list of GladOSQuotes
        /// </summary>
        /// <returns>A List of <see cref="PortalChapter"/>.</returns>
        public Task<IEnumerable<PortalChapter>> GetGlaDOSQuotesAsync();
    }
}

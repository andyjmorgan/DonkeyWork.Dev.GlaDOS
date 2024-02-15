using System.Text.RegularExpressions;
using DonkeyWork.Dev.GladOS.WikipediaConnector.Interface;
using DonkeyWork.Dev.GladOS.WikipediaConnector.Model.GladOSQuotes;
using HtmlAgilityPack;

namespace DonkeyWork.Dev.GladOS.WikipediaConnector.Service
{
    public class WikipediaConnector : IWikipediaConnector
    {
        private const string WikiUrl = "https://theportalwiki.com/wiki/GLaDOS_voice_lines_(Portal_2)";

        public async Task<IEnumerable<PortalChapter>> GetGlaDOSQuotesAsync()
        {
            var htmlContent = await GetWikipediaContentAsync();
            ArgumentNullException.ThrowIfNull(htmlContent);

            return GetQuotesFromHtml(htmlContent);
        }

        private async Task<HtmlDocument?> GetWikipediaContentAsync()
        {
            HtmlWeb webRequester = new();
            return await webRequester.LoadFromWebAsync(WikiUrl);
        }

        private List<PortalChapter> GetQuotesFromHtml(HtmlDocument? htmlDocument)
        {
            List<PortalChapter> portalChapters = new();
            ArgumentNullException.ThrowIfNull(htmlDocument);
            var contentNode = htmlDocument.DocumentNode.SelectNodes("//div[contains(@class, 'mw-parser-output')]");

            foreach (var node in contentNode.Nodes())
            {
                switch (node.Name)
                {
                    case "h1":
                        if (node.InnerText.StartsWith("chapter", StringComparison.InvariantCultureIgnoreCase))
                        {
                            portalChapters.Add(new PortalChapter
                            {
                                Name = node.InnerText,
                            });
                        }
                        break;
                    case "h2":
                        portalChapters.LastOrDefault()?.Levels.Add(new PortalLevel
                        {
                            Name = node.InnerText,
                        });
                        break;
                    case "ul":

                        foreach (var childNode in node.ChildNodes.Where(x =>
                                     string.Equals(x.Name, "li", StringComparison.InvariantCultureIgnoreCase)))
                        {
                            var quotes = Regex.Match(childNode.InnerHtml, @"<i>.*</i>");
                            var wavUrls = Regex.Match(childNode.InnerHtml,
                                @"(http|ftp|https):\/\/([\w_-]+(?:(?:\.[\w_-]+)+))([\w.,@?^=%&:\/~+#-]*[\w@?^=%&\/~+#-]).wav");
                            if (wavUrls.Captures.Any() && quotes.Captures.Any())
                            {

                                portalChapters
                                    .LastOrDefault()?.Levels
                                    .LastOrDefault()?.Quotes
                                    .Add(
                                        new GlaDOSQuote
                                        {
                                            QuoteText = RemoveItalicTags(quotes.Captures.First().Value.Trim()),
                                            AudioFile = new Uri(wavUrls.Captures.First().Value)
                                        });
                            }
                        }
                        break;
                }
            }

            return portalChapters;
        }

        private string RemoveItalicTags(string entry)
        {
            return entry
                .Replace("<i>", "", StringComparison.InvariantCultureIgnoreCase)
                .Replace("</i>", string.Empty, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}

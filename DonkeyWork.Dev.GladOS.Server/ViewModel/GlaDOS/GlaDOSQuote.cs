namespace DonkeyWork.Dev.GladOS.Server.ViewModel.GlaDOSQuotes
{
    public class GlaDOSQuote
    {
        public string ChapterName { get; set; }
        public string LevelName { get; set; }
        public List<string> Quotes { get; set; } = new List<string>();
        public List<string> AudioUris { get; set; } = new List<string>();
    }
}

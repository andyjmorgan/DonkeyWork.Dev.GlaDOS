using DonkeyWork.Dev.GladOS.Server.ViewModel.GlaDOSQuotes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DonkeyWork.Dev.GladOS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlaDOSQuotesController(IMemoryCache memoryCache) : ControllerBase
    {
        private readonly Random random = new Random();

        // GET: api/<GlaDOSQuotesController>
        [HttpGet]
        public ActionResult<GlaDOSQuote> Get()
        {
            var chapters = memoryCache.Get<List<WikipediaConnector.Model.GladOSQuotes.PortalChapter>?>("GlaDOSQuotes");
            if (chapters == null)
            {
                return new NotFoundResult();
            }

            var randomChapter = chapters[random.Next(0, chapters.Count - 1)];
            var randomLevel = randomChapter.Levels[random.Next(0, randomChapter.Levels.Count - 1)];

            return Ok(new GlaDOSQuote
            {
                LevelName = randomLevel.Name!,
                Quotes = randomLevel.Quotes.Select(x => x.QuoteText!).ToList(),
                ChapterName = randomChapter.Name!,
                AudioUris = randomLevel.Quotes.Select(x => x.AudioFile!.ToString()).ToList()
            });
        }
    }
}

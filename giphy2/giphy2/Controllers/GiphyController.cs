using System.Threading.Tasks;
using giphy2.Services;
using Microsoft.AspNetCore.Mvc;

namespace giphy2.Controllers
{    
    public class GiphyController : Controller
    {
        private readonly IGiphyService _giphyService;

        public GiphyController(IGiphyService giphyService)
        {
            _giphyService = giphyService;
        }

        [HttpGet]
        [Route("random/{searchCriteria}")]
        public async Task<IActionResult> GetRandomGif(string searchCriteria)
        {
            var result = await _giphyService.ReturnRandomGifAsync(searchCriteria);

            return Ok(result);
        }
    }
}
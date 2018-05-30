using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Giphy.Libs.Models;

namespace Giphy.Libs.Services
{
    public class GiphyService : IGiphyService
    {
        private readonly IGetRandomGif _getRandomGif;

        public GiphyService(IGetRandomGif getRandomGif)
        {
            _getRandomGif = getRandomGif;
        }

        public async Task<GiphyModel> GetRandomGifBasedOnSearchCriteria(string searchCriteria)
        {
            return await _getRandomGif.ReturnRandomGifBasedOnTag(searchCriteria);
        }
    }
}

using System;
using System.Net.Http;
using System.Threading.Tasks;
using giphy2.Models;
using Newtonsoft.Json;

namespace giphy2.Services
{
    public class GiphyService : IGiphyService
    {
        public async Task<GiphyModel> ReturnRandomGifAsync(string searchCriteria)
        {
            const string giphyKey = "8xCc9oDNGiUKZxXoxYAvwy5bq34JnChj";

            using (var client = new HttpClient())
            {
                var url = new Uri($"http://api.giphy.com/v1/gifs/search?api_key=" + $"{giphyKey}&q={searchCriteria}&limit=1");
                var response = await client.GetAsync(url);

                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }

                return JsonConvert.DeserializeObject<GiphyModel>(json);
            }
        }
    }
}

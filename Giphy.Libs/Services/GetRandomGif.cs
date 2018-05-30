using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Giphy.Libs.Models;
using Newtonsoft.Json;

namespace Giphy.Libs.Services
{
    public class GetRandomGif : IGetRandomGif
    {
        public async Task<GiphyModel> ReturnRandomGifBasedOnTag(string searchCriteria)
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

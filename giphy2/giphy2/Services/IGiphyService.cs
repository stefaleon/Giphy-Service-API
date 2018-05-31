using giphy2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace giphy2.Services
{
    public interface IGiphyService
    {
        Task<GiphyModel> ReturnRandomGifAsync(string searchCriteria);
    }
}

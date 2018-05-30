using Giphy.Libs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Giphy.Libs.Services
{
    public interface IGiphyService
    {
        Task<GiphyModel> GetRandomGifBasedOnSearchCriteria(string searchCriteria);
    }
}

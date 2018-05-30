using Giphy.Libs.Models;
using System.Threading.Tasks;

namespace Giphy.Libs.Services
{
    public interface IGetRandomGif
    {
        Task<GiphyModel> ReturnRandomGifBasedOnTag(string searchCriteria);
    }
}
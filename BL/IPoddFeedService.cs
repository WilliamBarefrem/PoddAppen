using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace BL
{
    public interface IPoddFeedService
    {
      
        Task AddAsync(PoddFeed feed);
        Task<List<PoddFeed>> GetAllAsync();
        Task<PoddFeed?> GetByIdAsync(string id);
        Task<bool> UpdateAsync(PoddFeed feed);
        Task<bool> DeleteAsync(string id);

      
        Task<List<Episode>> LoadEpisodesFromRssAsync(string rssUrl);
    }
}
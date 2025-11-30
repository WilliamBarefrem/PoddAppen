using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using Models;

namespace BL
{
    public class PoddFeedService : IPoddFeedService
    {
        private readonly IRepository<PoddFeed> _repo;

        public PoddFeedService(IRepository<PoddFeed> repo)
        {
            _repo = repo;
        }

      
        public async Task AddAsync(PoddFeed feed)
        {
            if (feed == null) return;
            if (string.IsNullOrWhiteSpace(feed.Name)) return;
            if (string.IsNullOrWhiteSpace(feed.RssUrl)) return;

            await _repo.AddAsync(feed);
        }

    
        public Task<List<PoddFeed>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }

        
        public Task<PoddFeed?> GetByIdAsync(string id)
        {
            return _repo.GetByIdAsync(id);
        }

        
        public async Task<bool> UpdateAsync(PoddFeed feed)
        {
            if (feed == null) return false;
            if (string.IsNullOrWhiteSpace(feed.Name)) return false;
            if (string.IsNullOrWhiteSpace(feed.RssUrl)) return false;

            return await _repo.UpdateAsync(feed);
        }

     
        public Task<bool> DeleteAsync(string id)
        {
            return _repo.DeleteAsync(id);
        }

       
        public async Task<List<Episode>> LoadEpisodesFromRssAsync(string rssUrl)
        {
            var episodes = new List<Episode>();

            if (string.IsNullOrWhiteSpace(rssUrl))
                return episodes;

            try
            {
                
                using var http = new System.Net.Http.HttpClient();
                string xml = await http.GetStringAsync(rssUrl);

                var doc = XDocument.Parse(xml);
                var items = doc.Descendants("item");

                foreach (var item in items)
                {
                    var episode = new Episode
                    {
                        Title = (string?)item.Element("title") ?? "",
                        Description = (string?)item.Element("description") ?? ""
                    };

                    var pubDateString = (string?)item.Element("pubDate");
                    if (DateTime.TryParse(pubDateString, out var pubDate))
                    {
                        episode.PublishDate = pubDate;
                    }

                    episodes.Add(episode);
                }
            }
            catch
            {
               
            }

            return episodes;
        }
    }
}
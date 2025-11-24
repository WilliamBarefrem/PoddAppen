using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void Add(PoddFeed feed)
        {
            if (feed == null) return;

            // enkel validering – här bor dina "regler"
            if (string.IsNullOrWhiteSpace(feed.Name)) return;
            if (string.IsNullOrWhiteSpace(feed.RssUrl)) return;

            _repo.Add(feed);
        }

        public List<PoddFeed> GetAll()
        {
            return _repo.GetAll();
        }

        public PoddFeed? GetById(string id)
        {
            return _repo.GetById(id);
        }

        public bool Update(PoddFeed feed)
        {
            if (feed == null) return false;
            if (string.IsNullOrWhiteSpace(feed.Name)) return false;
            if (string.IsNullOrWhiteSpace(feed.RssUrl)) return false;

            return _repo.Update(feed);
        }

        public bool Delete(string id)
        {
            return _repo.Delete(id);
        }

        public List<Episode> LoadEpisodesFromRss(string rssUrl)
        {
            var episodes = new List<Episode>();

            if (string.IsNullOrWhiteSpace(rssUrl))
                return episodes;

            try
            {
                var doc = XDocument.Load(rssUrl);

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
                // För kursen kan du nöja dig med att bara svälja fel här
                // eller logga om du vill.
            }

            return episodes;
        }
    }
}
    


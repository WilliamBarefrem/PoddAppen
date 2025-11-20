using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
    


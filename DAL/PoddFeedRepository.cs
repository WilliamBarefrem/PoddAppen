
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BL;

namespace DAL
{
    public class PoddFeedRepository : IRepository<PoddFeed>
    {
        private readonly List<PoddFeed> _feeds;

        public PoddFeedRepository()
        {
            _feeds = new List<PoddFeed>();
        }

        // CREATE
        public void Add(PoddFeed item)
        {
            item.Id = (_feeds.Count + 1).ToString();
            _feeds.Add(item);
        }

        // READ – alla
        public List<PoddFeed> GetAll()
        {
            return _feeds;
        }

        // READ – en
        public PoddFeed? GetById(string id)
        {
            return _feeds.FirstOrDefault(f => f.Id == id);
        }

        // UPDATE
        public bool Update(PoddFeed item)
        {
            var existing = GetById(item.Id);
            if (existing == null) return false;

            existing.Name = item.Name;
            existing.RssUrl = item.RssUrl;
            return true;
        }

        // DELETE
        public bool Delete(string id)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            _feeds.Remove(existing);
            return true;
        }
    }
}

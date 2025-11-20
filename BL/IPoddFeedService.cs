using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BL
{
    public interface IPoddFeedService
    {
        void Add(PoddFeed feed);
        List<PoddFeed> GetAll();
        PoddFeed? GetById(string id);
        bool Update(PoddFeed feed);
        bool Delete (string id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IRepository<T>
    {
        public void Add(T item);
        List<T> GetAll();
        T? GetById(string Id);
        bool Update (T item);
        bool Delete(string Id);

    }
}

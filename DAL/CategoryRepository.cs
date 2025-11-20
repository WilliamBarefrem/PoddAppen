using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class CategoryRepository 
    {
        private readonly List<Category> _categories = new();

        public void Add (Category item)
        {
            if (string.IsNullOrWhiteSpace(item.Id))item.Id = (_categories.Count + 1).ToString();
            _categories.Add(item);
        }

        public List<Category> GetAll()
        {
            return _categories.ToList();
        }

        public Category? GetById(string id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }

        public bool Update(Category item)
        {
            var existing = GetById(item.Id);
            if (existing == null) return false;

            existing.Name = item.Name;
            return true;
        }

        public bool Delete (string id)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            _categories.Remove(existing);
            return true;
        }
    }
}

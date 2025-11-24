using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Models;

namespace BL
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepo;

        public CategoryService(IRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public void Add(Category category)
        {
            if (category == null) return;
            if (string.IsNullOrWhiteSpace(category.Name)) return;

            _categoryRepo.Add(category);
        }

        public List<Category> GetAll()
        {
            return _categoryRepo.GetAll();
        }

        public Category? GetById(string id)
        {
            return _categoryRepo.GetById(id);
        }

        public bool Update(Category category)
        {
            if (category == null) return false;
            if (string.IsNullOrWhiteSpace(category.Name)) return false;

            return _categoryRepo.Update(category);
        }

        public bool Delete(string id)
        {
            return _categoryRepo.Delete(id);
        }
    }
}
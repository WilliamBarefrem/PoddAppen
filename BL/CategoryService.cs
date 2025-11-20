using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BL
{
    public class CategoryService
    {
        private readonly IRepository<Category> _categoryRepo;

        public CategoryService(IRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        } 

        public void CreateCategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Kategorinamn far inte vara tomt.");

            var category = new Category { Name  = name };
            _categoryRepo.Add(category);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepo.GetAll();
        }

        public bool RenameCategory (string id, string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentNullException("Nytt namn f[r inte vara tomt.");

            var category = _categoryRepo.GetById(id);
            return _categoryRepo.Update(category);
        }

        public bool DeleteCategory(string id) 
        {
            return _categoryRepo.Delete(id);
        }
    }
}

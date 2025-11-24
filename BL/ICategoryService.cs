using System.Collections.Generic;
using Models;

namespace BL
{
    public interface ICategoryService
    {
        void Add(Category category);
        List<Category> GetAll();
        Category? GetById(string id);
        bool Update(Category category);
        bool Delete(string id);
    }
}
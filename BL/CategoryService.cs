using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task AddAsync(Category category)
        {
            if (category == null) return;
            if (string.IsNullOrWhiteSpace(category.Name)) return;

            await _categoryRepo.AddAsync(category);
        }

        public Task<List<Category>> GetAllAsync()
        {
            return _categoryRepo.GetAllAsync();
        }

        public Task<Category?> GetByIdAsync(string id)
        {
            return _categoryRepo.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            if (category == null) return false;
            if (string.IsNullOrWhiteSpace(category.Name)) return false;

            return await _categoryRepo.UpdateAsync(category);
        }

        public Task<bool> DeleteAsync(string id)
        {
            return _categoryRepo.DeleteAsync(id);
        }
    }
}
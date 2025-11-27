using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace BL
{
    public interface ICategoryService
    {
        Task AddAsync(Category category);
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(string id);
        Task<bool> UpdateAsync(Category category);
        Task<bool> DeleteAsync(string id);
    }
}
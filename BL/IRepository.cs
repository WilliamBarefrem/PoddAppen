using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IRepository<T>
    {
        Task AddAsync(T item);
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(string id);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(string id);
    }
}
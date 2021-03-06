using LibApp.Domain.Models.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibApp.Data.Repository.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<int> AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);
        Task<T> GetByIdAsync(int id, bool noTracking = false);
        Task<IList<T>> GetAllAsync();
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteByIdAsync(int id);
    }
}

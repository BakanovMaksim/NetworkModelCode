using NetworkModelCode.Core.Domain.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetworkModelCode.Core.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}

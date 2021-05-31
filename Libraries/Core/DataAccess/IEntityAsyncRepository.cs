using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityAsyncRepository<T>
    {
        Task AddAsync(T entity);
        Task AddAsync(IList<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteAsync(IList<T> entities);
        Task<int> DeleteAsync(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int? id);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
        Task UpdateAsync(T entity);
        Task UpdateAsync(IList<T> entities);
        Task<int> SaveChangesAsync();
    }
}

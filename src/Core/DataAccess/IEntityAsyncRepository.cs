using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityAsyncRepository<T>
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int? id);
    
        Task<int> SaveChangesAsync();
    }
}

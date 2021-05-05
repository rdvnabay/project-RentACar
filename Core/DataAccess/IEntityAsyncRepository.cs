using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityAsyncRepository<T>
    {
       
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int? id);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
     
        Task AddAsync(T entity);
        Task AddAsync(IList<T> entities);

        Task UpdateAsync(T entity);
        Task UpdateAsync(IList<T> entities);

        Task DeleteAsync(T entity);
        Task DeleteAsync(IList<T> entities);
        Task<int> DeleteAsync(Expression<Func<T, bool>> expression);
    }
}

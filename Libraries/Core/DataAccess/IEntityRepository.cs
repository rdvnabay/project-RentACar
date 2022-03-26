using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<T>
    {
        void Add(T entity);
        void AddRange(IList<T> entities);
        void Update(T entity);
        void UpdateRange(IList<T> entities);
        void Delete(T entity);
        void DeleteRange(IList<T> entities);

        List<T> GetAll(Expression<Func<T, bool>> expression = null);
        T Get(Expression<Func<T, bool>> expression);
        T GetById(int id);

        int SaveChanges();
    }
}

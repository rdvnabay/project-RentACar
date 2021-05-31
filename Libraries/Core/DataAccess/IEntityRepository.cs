using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<T>
    {
        void Add(T entity);
        void AddMultiple(IList<T> entities);
        void Delete(T entity);
        void Delete(IList<T> entities);
        int Delete(Expression<Func<T, bool>> expression);
        T Get(Expression<Func<T, bool>> expression);
        List<T> GetAll(Expression<Func<T, bool>> expression = null);
        T GetById(int id);
        void Update(T entity);
        void Update(IList<T> entities);
        int SaveChanges();
    }
}

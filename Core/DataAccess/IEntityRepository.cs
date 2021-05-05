using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T>
    {
        T Get(Expression<Func<T, bool>> expression);

        T GetById(int id);

        List<T> GetAll(Expression<Func<T, bool>> expression = null);


        void Add(T entity);
        void Add(IList<T> entities);


        void Update(T entity);
        void Update(IList<T> entities);


        void Delete(T entity);
        void Delete(IList<T> entities);
        int Delete(Expression<Func<T, bool>> expression);
    }
}

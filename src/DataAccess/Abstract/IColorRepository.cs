using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IColorRepository:IEntityRepository<Color>,IEntityAsyncRepository<Color>
    {
    }
}

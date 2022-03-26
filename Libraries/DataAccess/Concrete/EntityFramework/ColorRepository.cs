using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class ColorRepository:EfEntityRepositoryBase<Color,RentACarDbContext>,IColorRepository
    {
        public ColorRepository(RentACarDbContext context) : base(context) { }
    }
}

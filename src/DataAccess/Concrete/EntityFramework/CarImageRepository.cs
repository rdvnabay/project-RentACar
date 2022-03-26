using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarImageRepository:EfEntityRepositoryBase<CarImage,RentACarDbContext>,ICarImageRepository
    {
       public CarImageRepository(RentACarDbContext context) : base(context) { }
    }
}

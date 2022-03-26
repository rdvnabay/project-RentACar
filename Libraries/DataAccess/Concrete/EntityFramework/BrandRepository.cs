using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class BrandRepository:EfEntityRepositoryBase<Brand,RentACarDbContext>,IBrandRepository
    {
       public BrandRepository(RentACarDbContext context) : base(context) { }
    }
}

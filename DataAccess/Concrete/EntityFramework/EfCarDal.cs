using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarDbContext>, ICarDal
    {
        public List<CarForDetailDto> GetCarDetails()
        {
            using (var context = new RentACarDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarForDetailDto
                             {
                                 CarName = c.Name,
                                 DailyPrice = c.DailyPrice,
                                 BrandName = b.Name,
                                 ColorName = co.Name
                             };
                return result.ToList();
            }
        }
    }
}

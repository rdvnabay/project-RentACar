using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarDbContext>, ICarDal
    {
        public List<CarForListDto> GetAllDto(Expression<Func<CarForListDto, bool>> filter = null)
        {
            using (var context = new RentACarDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarForListDto
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 DailyPrice = c.DailyPrice,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }


        public CarForListDto GetDetails(int carId)
        {
            using (var context = new RentACarDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             where c.Id == carId
                             select new CarForListDto
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear
                             };
                return result.FirstOrDefault();
            }
        }
    }
}


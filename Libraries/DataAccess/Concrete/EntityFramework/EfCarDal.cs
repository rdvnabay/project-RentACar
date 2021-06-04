using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Car;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarDbContext>, ICarDal
    {
        public EfCarDal(RentACarDbContext context) : base(context) { }

        public List<CarDto> GetAllByBrandIdAndColorId(int brandId, int colorId)
        {
            using (var context = new RentACarDbContext())
            {
                var result = from c in context.Cars.Where(x => x.BrandId == brandId && x.ColorId == colorId)
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDto
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear
                             };
                return result.ToList();
            }
        }

        public List<CarDto> GetAllBySearch(string search)
        {
            using (var context = new RentACarDbContext())
            {
                var result = from c in string.IsNullOrEmpty(search)
                             ? context.Cars
                             : context.Cars.Where(x => x.Name.ToUpper().Contains(search))
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDto
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear
                             };
                return result.ToList();
            }
        }

        public async Task<List<CarDto>> GetAllDto()
        {
            using (var context = new RentACarDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDto
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear
                             };
                return await result.ToListAsync();
            }
        }

        public CarDto GetDetails(int carId)
        {
            using (var context = new RentACarDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             where c.Id == carId
                             select new CarDto
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


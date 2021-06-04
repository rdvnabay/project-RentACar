using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarDbContext>, IRentalDal
    {
        public EfRentalDal(RentACarDbContext context) : base(context) { }

        public List<RentalListDto> GetAllDto()
        {
            using (var context = new RentACarDbContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id

                             join customer in context.Customers
                             on rental.CustomerId equals customer.Id
                             join user in context.Users
                             on customer.Id equals user.Id
                             select new RentalListDto
                             {
                                 BrandName = brand.Name,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName
                             };
                return result.ToList();
            }
        }

        public List<RentalListDto> GetRentAllByCustomer(int carId, int customerId)
        {
            using (var context = new RentACarDbContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id

                             join customer in context.Customers
                             on rental.CustomerId equals customer.Id
                             join user in context.Users
                             on customer.Id equals user.Id
                             where car.Id == carId && customer.Id == customerId
                             select new RentalListDto
                             {
                                 BrandName = brand.Name,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName
                             };
                return result.ToList();
            }
        }
    }
}

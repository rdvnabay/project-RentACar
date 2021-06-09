using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Rental;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarDbContext>, IRentalDal
    {
        public EfRentalDal(RentACarDbContext context) : base(context) { }

        public List<RentalDto> GetAllRentalWithCustomerAndBrand()
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
                             select new RentalDto
                             {
                                 BrandName = brand.Name,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName
                             };
                return result.ToList();
            }
        }
        public async Task<List<RentalDto>> GetAllRentalWithCustomerAndBrandAsync()
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
                             select new RentalDto
                             {
                                 BrandName = brand.Name,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName
                             };
                return await result.ToListAsync();
            }
        }
        public List<RentalDto> GetRentAllByCustomer(int carId, int customerId)
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
                             select new RentalDto
                             {
                                 BrandName = brand.Name,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName
                             };
                return result.ToList();
            }
        }
        public async Task<RentalDto> GetRentalWithCustomerAndBrandAsync(int rentalId)
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
                             where rental.Id==rentalId
                             select new RentalDto
                             {
                                 BrandName = brand.Name,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName
                             };
                return await result.FirstOrDefaultAsync();
            }
        }
    }
}

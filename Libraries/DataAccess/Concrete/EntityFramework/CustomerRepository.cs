using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class CustomerRepository:EfEntityRepositoryBase<Customer, RentACarDbContext>,ICustomerRepository
    {
        public CustomerRepository(RentACarDbContext context) : base(context) { }
    }
}

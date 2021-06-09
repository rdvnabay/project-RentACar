using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.Rental;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>,IEntityAsyncRepository<Rental>
    {
        List<RentalDto> GetRentAllByCustomer(int carId, int customerId);
        List<RentalDto> GetAllRentalWithCustomerAndBrand();
        Task<List<RentalDto>> GetAllRentalWithCustomerAndBrandAsync();
    }
}

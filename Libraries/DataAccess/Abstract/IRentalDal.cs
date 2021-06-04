using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.Rental;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>,IEntityAsyncRepository<Rental>
    {
        List<RentalDto> GetRentAllByCustomer(int carId, int customerId);
        List<RentalDto> GetAllDto();
    }
}

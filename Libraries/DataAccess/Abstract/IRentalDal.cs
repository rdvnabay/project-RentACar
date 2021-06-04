using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.Rental;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalListDto> GetRentAllByCustomer(int carId, int customerId);
        List<RentalListDto> GetAllDto();
    }
}

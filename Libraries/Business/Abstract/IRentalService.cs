using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(RentalAddDto rentalAddDto);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<Rental> GetById(int rentalId);
        IDataResult<List<RentalListDto>> GetAll();
        IDataResult<List<RentalListDto>>GetRentAllByCustomer(int carId, int  customerId);
    }
}

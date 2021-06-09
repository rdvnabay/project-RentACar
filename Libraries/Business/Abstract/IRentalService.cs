using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos.Rental;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(RentalAddDto rentalAddDto);
        Task<IResult> AddAsync(RentalAddDto rentalAddDto);
        IResult Update(Rental rental);
        Task<IResult> UpdateAsync(RentalUpdateDto rentalUpdateDto);
        IResult Delete(Rental rental);
        IDataResult<Rental> GetById(int rentalId);
        IDataResult<List<RentalDto>> GetAll();
        Task<IDataResult<List<RentalDto>>> GetAllAsync();
        IDataResult<List<RentalDto>>GetRentAllByCustomer(int carId, int  customerId);
     
    }
}

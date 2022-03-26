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
        IResult Update(RentalUpdateDto rentalDto);
        IResult DeleteById(int rentalId);
        IDataResult<RentalDto> GetById(int rentalId);
        Task<IDataResult<RentalDto>> GetByIdAsync(int rentalId);
        IDataResult<List<RentalDto>> GetAll();
        Task<IDataResult<List<RentalDto>>> GetAllAsync();
        IDataResult<List<RentalDto>>GetRentAllByCustomer(int carId, int  customerId);
        Task<IDataResult<RentalDto>> GetRentAllByCustomerAsync(int carId, int customerId);
    }
}

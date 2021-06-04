using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        //Command
        IResult Add(CustomerAddDto customerAddDto);
        Task<IResult> AddAsync(CustomerAddDto customerAddDto);
        IResult DeleteById(int userId);
        Task<IResult> DeleteByIdAsync(int userId);
        IResult Update(Customer customer);
        Task<IResult> UpdateAsync(Customer customer);
 
        //Query
        IDataResult<Customer> GetById(int userId);
        Task<IDataResult<Customer>> GetByIdAsync(int userId);
        IDataResult<List<Customer>> GetAll();
        Task<IDataResult<List<Customer>>> GetAllAsync();
    }
}

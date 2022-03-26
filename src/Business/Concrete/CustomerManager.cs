using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        private ICustomerRepository _customerDal;
        private IMapper _mapper;
        public CustomerManager(ICustomerRepository customerDal, IMapper mapper)
        {
            _customerDal = customerDal;
        }

        //Command
        //[ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(CustomerAddDto customerAddDto)
        {
            var customer = _mapper.Map<Customer>(customerAddDto);
            _customerDal.Add(customer);
            return new SuccessResult();
        }
        public async Task<IResult> AddAsync(CustomerAddDto customerAddDto)
        {
            var customer = _mapper.Map<Customer>(customerAddDto);
            await _customerDal.AddAsync(customer);
            return new SuccessResult();
        }
        public IResult DeleteById(int userId)
        {
            var customer = _customerDal.Get(x => x.UserId == userId);
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult();
        }

        //Query
        public IDataResult<List<Customer>> GetAll()
        {
            var customers = _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(customers);
        }
        public async Task<IDataResult<List<Customer>>> GetAllAsync()
        {
            var customers = await  _customerDal.GetAllAsync();
            return new SuccessDataResult<List<Customer>>(customers);
        }
        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == customerId));
        }
        public async Task<IDataResult<Customer>> GetByIdAsync(int userId)
        {
            var customer = await _customerDal.GetAsync(x=>x.UserId==userId);
            return new SuccessDataResult<Customer>(customer);
        }
    }
}

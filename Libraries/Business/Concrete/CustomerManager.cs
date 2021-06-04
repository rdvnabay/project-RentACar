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

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        private ICustomerDal _customerDal;
        private IMapper _mapper;
        public CustomerManager(ICustomerDal customerDal, IMapper mapper)
        {
            _customerDal = customerDal;
        }
        //[ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(CustomerAddDto customerAddDto)
        {
            var customer = _mapper.Map<Customer>(customerAddDto);
            _customerDal.Add(customer);
            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var data = _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(data);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == customerId));
        }


        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult();
        }
    }
}

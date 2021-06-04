using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        private IRentalDal _rentalDal;
        private IMapper _mapper;
        public RentalManager(IRentalDal rentalDal, IMapper mapper)
        {
            _rentalDal = rentalDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(RentalAddDto rentalAddDto)
        {
            var rental = _mapper.Map<Rental>(rentalAddDto);
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<RentalListDto>> GetAll()
        {
            var data = _rentalDal.GetAllDto();
            return new SuccessDataResult<List<RentalListDto>>(data);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        } 

        public IDataResult<List<RentalListDto>> GetRentAllByCustomer(int carId, int customerId)
        {
            var data = _rentalDal.GetRentAllByCustomer(carId, customerId);
            return new SuccessDataResult<List<RentalListDto>>(data);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}

using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Rental;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<IResult> AddAsync(RentalAddDto rentalAddDto)
        {
            var rental = _mapper.Map<Rental>(rentalAddDto);
            await _rentalDal.AddAsync(rental);
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<RentalDto>> GetAll()
        {
            var rentals = _rentalDal.GetAllRentalWithCustomerAndBrand();
            return new SuccessDataResult<List<RentalDto>>(rentals);
        }

        public async Task<IDataResult<List<RentalDto>>> GetAllAsync()
        {
            var rentals = await _rentalDal.GetAllRentalWithCustomerAndBrandAsync();
            return new SuccessDataResult<List<RentalDto>>(rentals);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        } 

        public IDataResult<List<RentalDto>> GetRentAllByCustomer(int carId, int customerId)
        {
            var data = _rentalDal.GetRentAllByCustomer(carId, customerId);
            return new SuccessDataResult<List<RentalDto>>(data);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(RentalUpdateDto rentalUpdateDto)
        {
            var rental = _mapper.Map<Rental>(rentalUpdateDto);
            await _rentalDal.UpdateAsync(rental);
            return new SuccessResult();
        }
    }
}

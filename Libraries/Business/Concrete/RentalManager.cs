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

        //Methods
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
        public IResult DeleteById(int rentalId)
        {
            var rental = _rentalDal.Get(x => x.Id == rentalId);
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteByIdAsync(int rentalId)
        {
            var rental = await _rentalDal.GetAsync(x => x.Id == rentalId);
            await _rentalDal.DeleteAsync(rental);
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
        public IDataResult<RentalDto> GetById(int rentalId)
        {
            var rental = _rentalDal.Get(x => x.Id == rentalId);
            var rentalDto = _mapper.Map<RentalDto>(rental);
            return new SuccessDataResult<RentalDto>(rentalDto);
        }
        public async Task<IDataResult<RentalDto>> GetByIdAsync(int rentalId)
        {
            var rentalDto =await _rentalDal.GetRentalWithCustomerAndBrandAsync(rentalId);
            return new SuccessDataResult<RentalDto>(rentalDto);
        }
        public IDataResult<List<RentalDto>> GetRentAllByCustomer(int carId, int customerId)
        {
            var data = _rentalDal.GetRentAllByCustomer(carId, customerId);
            return new SuccessDataResult<List<RentalDto>>(data);
        }

        public Task<IDataResult<RentalDto>> GetRentAllByCustomerAsync(int carId, int customerId)
        {
            throw new System.NotImplementedException();
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

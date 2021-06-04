using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;
        IMapper _mapper;
        public CarManager(
            ICarDal carDal, 
            ICarImageService carImageService,
            IMapper mapper)
        {
            _carDal = carDal;
            _carImageService = carImageService;
            _mapper = mapper;
        }

        //[SecuredOperation("admin,car-add")]
        //[ValidationAspect(typeof(CarValidator))]
        public IResult Add(CarAddDto carAddDto)
        {
            //IResult result = BusinessRules.Run(CheckIfImageCountOfCarCorrect(1));
            var car = _mapper.Map<Car>(carAddDto);
            var carImage = _mapper.Map<CarImageAddDto>(carAddDto);
            _carDal.Add(car);
            carImage.CarId = car.Id;
            _carImageService.Add(carImage);
            return new SuccessResult();
        }

        public async Task<IResult> AddAsync(CarAddDto carAddDto)
        {
            var car = _mapper.Map<Car>(carAddDto);
            var carImageAddDto = _mapper.Map<CarImageAddDto>(carAddDto);
            await _carDal.AddAsync(car);
            carImageAddDto.CarId = car.Id;
            await _carImageService.AddAsync(carImageAddDto);
            return new SuccessResult();
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }
        public async Task<IResult> DeleteByIdAsync(int carId)
        {
            var car = _carDal.Get(x => x.Id == carId);
            await _carDal.DeleteAsync(car);
            return new SuccessResult();
        }
        public IDataResult<List<CarDto>> GetAll()
        {
            var cars = _carDal.GetAll();
            var carsDto = _mapper.Map<List<CarDto>>(cars);
            return new SuccessDataResult<List<CarDto>>(carsDto);
        }

        public IDataResult<Car> GetById(int carId)
        {
            var data=_carDal.Get(c => c.Id == carId);
            return new SuccessDataResult<Car>(data);
        }

        public IDataResult<List<Car>> GetAllByBrand(int brandId)
        {
            var data=_carDal.GetAll(c => c.BrandId == brandId);
            return new SuccessDataResult<List<Car>>(data);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAllByColor(int colorId)
        {
            var data = _carDal.GetAll(c => c.ColorId == colorId);
            return new SuccessDataResult<List<Car>>(data);
        }

        public IDataResult<CarDto> GetDetails(int carId)
        {
            var data = _carDal.GetDetails(carId);
            return new SuccessDataResult<CarDto>(data);
        }

        public async Task<IDataResult<List<CarDto>>> GetAllAsync()
        {
            var carsDto = await _carDal.GetAllDto();
            return new SuccessDataResult<List<CarDto>>(carsDto);
        }

        public IDataResult<List<CarDto>> GetAllBySearch(string search)
        {
             var data= _carDal.GetAllBySearch(search);
            return new SuccessDataResult<List<CarDto>>(data);
        }
        public IDataResult<List<CarDto>> GetAllByBrandIdAndColorId(int brandId, int colorId)
        {
            var carsDto = _carDal.GetAllByBrandIdAndColorId(brandId, colorId);
            return new SuccessDataResult<List<CarDto>>(carsDto);
        }

        //BusinessRules
        private IResult CheckIfImageCountOfCarCorrect(int carId)
        {
            var imageCount = _carImageService.GetImagesByCarId(carId).Data.Count;
            if (imageCount > 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}

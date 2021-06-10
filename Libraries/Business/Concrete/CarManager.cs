using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Car;
using Entities.Dtos.CarImage;
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

        //Command
        //[SecuredOperation("admin,car-add")]
        //[ValidationAspect(typeof(CarValidator))]
        public IResult Add(CarAddDto carAddDto)
        {
            //IResult result = BusinessRules.Run(CheckIfImageCountOfCarCorrect(1));
            var car = _mapper.Map<Car>(carAddDto);
            var carImage = _mapper.Map<CarImageAddDto>(carAddDto);
            _carDal.Add(car);
            carImage.CarId = car.Id;
           // _carImageService.Add(carImage);
            return new SuccessResult();
        }
        public async Task<IResult> AddAsync(CarAddDto carAddDto)
        {
            var car = _mapper.Map<Car>(carAddDto);
            var carImageAddDto = _mapper.Map<CarImageAddDto>(carAddDto);
            await _carDal.AddAsync(car);
            carImageAddDto.CarId = car.Id;
           // await _carImageService.AddAsync(carImageAddDto);
            return new SuccessResult();
        }
        public IResult DeleteById(int carId)
        {
            var car = _carDal.Get(x => x.Id == carId);
            _carDal.DeleteAsync(car);
            return new SuccessResult();
        }
        public async Task<IResult> DeleteByIdAsync(int carId)
        {
            var car = await _carDal.GetAsync(x => x.Id == carId);
            await _carDal.DeleteAsync(car);
            return new SuccessResult();
        }
        public IResult Update(CarUpdateDto carUpdateDto)
        {
            var car = _mapper.Map<Car>(carUpdateDto);
            _carDal.Update(car);
            return new SuccessResult();
        }
        public async Task<IResult> UpdateAsync(CarUpdateDto carUpdateDto)
        {
            var car = _mapper.Map<Car>(carUpdateDto);
            await _carDal.UpdateAsync(car);
            return new SuccessResult();
        }

        //Query
        public IDataResult<List<CarDto>> GetAll()
        {
            var carsDto = _carDal.GetAllCarWithBrandNameAndColorName();
            return new SuccessDataResult<List<CarDto>>(carsDto);
        }
        public async Task<IDataResult<List<CarDto>>> GetAllAsync()
        {
            var carsDto = await _carDal.GetAllCarWithBrandNameAndColorNameAsync();
            return new SuccessDataResult<List<CarDto>>(carsDto);
        }
        public IDataResult<CarDto> GetById(int carId)
        {
            var car = _carDal.GetCarWithBrandNameAndColorName(carId);
            return new SuccessDataResult<CarDto>(car);
        }
        public async Task<IDataResult<CarDto>> GetByIdAsync(int carId)
        {
            var car = await _carDal.GetCarWithBrandNameAndColorNameAsync(carId);
            return new SuccessDataResult<CarDto>(car);
        }
        public IDataResult<List<CarDto>> GetAllByBrand(int brandId)
        {
            var cars = _carDal.GetAll(c => c.BrandId == brandId);
            var carsDto = _mapper.Map<List<CarDto>>(cars);
            return new SuccessDataResult<List<CarDto>>(carsDto);
        }
        public async Task<IDataResult<List<CarDto>>> GetAllByBrandAsync(int brandId)
        {
            var cars = await _carDal.GetAsync(x => x.BrandId == brandId);
            var carsDto = _mapper.Map<List<CarDto>>(cars);
            return new SuccessDataResult<List<CarDto>>(carsDto);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<List<CarDto>> GetAllByColor(int colorId)
        {
            var cars = _carDal.GetAll(c => c.ColorId == colorId);
            var carsDto = _mapper.Map<List<CarDto>>(cars);
            return new SuccessDataResult<List<CarDto>>(carsDto);
        }
        public async Task<IDataResult<List<CarDto>>> GetAllByColorAsync(int colorId)
        {
            var cars = await _carDal.GetAsync(x => x.ColorId == colorId);
            var carsDto = _mapper.Map<List<CarDto>>(cars);
            return new SuccessDataResult<List<CarDto>>(carsDto);
        }
        public IDataResult<CarDto> GetDetail(int carId)
        {
            var car = _carDal.GetCarWithBrandNameAndColorName(carId);
            return new SuccessDataResult<CarDto>(car);
        }
        public async Task<IDataResult<CarDto>> GetDetailAsync(int carId)
        {
            var car = await _carDal.GetCarWithBrandNameAndColorNameAsync(carId);
            return new SuccessDataResult<CarDto>(car);
        }
        public IDataResult<List<CarDto>> GetAllBySearch(string search)
        {
            var data = _carDal.GetAllBySearch(search);
            return new SuccessDataResult<List<CarDto>>(data);
        }
        public async Task<IDataResult<List<CarDto>>> GetAllBySearchAsync(string search)
        {
            throw new System.NotImplementedException();
        }
        public IDataResult<List<CarDto>> GetAllByBrandIdAndColorId(int brandId, int colorId)
        {
            var carsDto = _carDal.GetAllByBrandIdAndColorId(brandId, colorId);
            return new SuccessDataResult<List<CarDto>>(carsDto);
        }
        public async Task<IDataResult<List<CarDto>>> GetAllByBrandIdAndColorIdAsync(int brandId, int colorId)
        {
            throw new System.NotImplementedException();
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

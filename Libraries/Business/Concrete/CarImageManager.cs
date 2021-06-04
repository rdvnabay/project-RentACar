using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.CarImage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private IMapper _mapper;
        public CarImageManager(ICarImageDal carImageDal, IMapper mapper)
        {
            _carImageDal = carImageDal;
            _mapper = mapper;
        }

        //Methods
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImageAddDto carImageAddDto)
        {
            IResult result = BusinessRules.Run(CheckIfImageCountOfCarCorrect(carImageAddDto.CarId),
                                               CheckIfCarImageNullOrEmpty(carImageAddDto));
            if (result != null)
            {
                return result;
            }
            var carImage = _mapper.Map<CarImage>(carImageAddDto);
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }
        public async Task<IResult> AddAsync(CarImageAddDto carImageAddDto)
        {
            IResult result = BusinessRules.Run(CheckIfImageCountOfCarCorrect(carImageAddDto.CarId),
                                               CheckIfCarImageNullOrEmpty(carImageAddDto));
            if (result != null)
            {
                return result;
            }
            var carImage = _mapper.Map<CarImage>(carImageAddDto);
            await _carImageDal.AddAsync(carImage);
            return new SuccessResult(Messages.Added);
        }
        public IResult Delete(CarImageDto carImageDto)
        {
            var carImage = _mapper.Map<CarImage>(carImageDto);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }
        public async Task<IResult> DeleteAsync(CarImageDto carImageDto)
        {
            var carImage = _mapper.Map<CarImage>(carImageDto);
            await _carImageDal.DeleteAsync(carImage);
            return new SuccessResult(Messages.Deleted);
        }
        public async Task<IResult> DeleteByIdAsync(int carId)
        {
            var carImage = await _carImageDal.GetAllAsync(x => x.CarId == carId);
            await _carImageDal.DeleteAsync(carImage);
            return new SuccessResult();
        }
        public IDataResult<List<CarImageDto>> GetAll()
        {
            var carImages = _carImageDal.GetAll();
            var carImagesDto = _mapper.Map<List<CarImageDto>>(carImages);
            return new SuccessDataResult<List<CarImageDto>>(carImagesDto);
        }

        public async Task<IDataResult<List<CarImageDto>>> GetAllAsync()
        {
            var carImages = await _carImageDal.GetAllAsync();
            var carImagesDto = _mapper.Map<List<CarImageDto>>(carImages);
            return new SuccessDataResult<List<CarImageDto>>(carImagesDto);
        }
        public IDataResult<CarImageDto> GetByCarId(int carId)
        {
            var carImage = _carImageDal.Get(c => c.CarId == carId);
            var carImageDto = _mapper.Map<CarImageDto>(carImage);
            return new SuccessDataResult<CarImageDto>(carImageDto);
        }
        public async Task<IDataResult<CarImageDto>> GetByCarIdAsync(int carId)
        {
            var carImage = await _carImageDal.GetAsync(x => x.CarId == carId);
            var carImageDto = _mapper.Map<CarImageDto>(carImage);
            return new SuccessDataResult<CarImageDto>(carImageDto);
        }
        public IDataResult<List<CarImageDto>> GetImagesByCarId(int carId)
        {
            var carImage = _carImageDal.GetAll(c => c.CarId == carId);
            var carImageDto = _mapper.Map<List<CarImageDto>>(carImage);
            return new SuccessDataResult<List<CarImageDto>>(carImageDto);
        }
        public async Task<IDataResult<List<CarImageDto>>> GetImagesByCarIdAsync(int carId)
        {
            var carImages = await _carImageDal.GetAllAsync(x => x.CarId == carId);
            var carImagesDto = _mapper.Map<List<CarImageDto>>(carImages);
            return new SuccessDataResult<List<CarImageDto>>(carImagesDto);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImageDto carImageDto)
        {
            IResult result = BusinessRules.Run(CheckIfImageCountOfCarCorrect(carImageDto.CarId));
            if (result != null)
            {
                return result;
            }
            var carImage = _mapper.Map<CarImage>(carImageDto);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
        public async Task<IResult> UpdateAsync(CarImageUpdateDto carImageUpdateDto)
        {
            IResult result = BusinessRules.Run(CheckIfImageCountOfCarCorrect(carImageUpdateDto.CarId));
            if (result != null)
            {
                return result;
            }
            var carImage = _mapper.Map<CarImage>(carImageUpdateDto);
            await _carImageDal.UpdateAsync(carImage);
            return new SuccessResult();
        }

        //Business Rules
        private IResult CheckIfImageCountOfCarCorrect(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImagesLimitExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarImageNullOrEmpty(CarImageAddDto carImageAddDto)
        {
            if (string.IsNullOrEmpty(carImageAddDto.ImagePath))
            {
                carImageAddDto.ImagePath = "default.jpg";
            }
            return new SuccessResult();
        }
    }
}

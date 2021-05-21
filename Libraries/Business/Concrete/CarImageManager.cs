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

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImageAddDto carImageAddDto)
        {
            IResult result = BusinessRules.Run(CheckIfImageCountOfCarCorrect(carImageAddDto.CarId));
            if (result != null)
            {
                return result;
            }
            var carImage = _mapper.Map<CarImage>(carImageAddDto);
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImageDto carImageDto)
        {
            var carImage = _mapper.Map<CarImage>(carImageDto);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImageDto> GetByCarId(int carId)
        {
            var carImage = _carImageDal.Get(c => c.CarId == carId);
            var carImageDto = _mapper.Map<CarImageDto>(carImage);
            return new SuccessDataResult<CarImageDto>(carImageDto);
        }

        public IDataResult<List<CarImageDto>> GetImagesByCarId(int carId)
        {
            var carImage = _carImageDal.GetAll(c => c.CarId == carId);
            var carImageDto = _mapper.Map<List<CarImageDto>>(carImage);
            return new SuccessDataResult<List<CarImageDto>>(carImageDto);
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

        private IResult CheckIfImageCountOfCarCorrect(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}

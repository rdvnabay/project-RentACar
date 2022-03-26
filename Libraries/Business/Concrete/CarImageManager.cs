using AutoMapper;
using Business.Abstract;
using Business.Adapters;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.CarImage;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageRepository _carImageDal;
        private IMapper _mapper;
        private IImageUploadService _imageUploadService;
        public CarImageManager(ICarImageRepository carImageDal, IMapper mapper, IImageUploadService imageUploadService)
        {
            _carImageDal = carImageDal;
            _mapper = mapper;
            _imageUploadService = imageUploadService;
        }

        //Command
        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImageAddDto carImageAddDto, IFormFile[] files)
        {
            IResult result = BusinessRules.Run(CheckIfImageCountOfCarCorrect(carImageAddDto.CarId,files),
                                               CheckIfMultipleImageUploadLimited(files),
                                               CheckIfCarImageNullOrEmpty(carImageAddDto, files));
            if (result != null)
                return result;
      
            foreach (var file in files)
            {
                var imagePath= _imageUploadService.Upload(file);
                CarImage carImage = new() { CarId = carImageAddDto.CarId, ImagePath=imagePath};
                _carImageDal.Add(carImage);
            }
            return new SuccessResult();
        }
        public async Task<IResult> AddAsync(CarImageAddDto carImageAddDto, IFormFile[] files)
        {
            IResult result = BusinessRules.Run(CheckIfImageCountOfCarCorrect(carImageAddDto.CarId, files),
                                               CheckIfMultipleImageUploadLimited(files),
                                               CheckIfCarImageNullOrEmpty(carImageAddDto, files));
            if (result != null)
                return result;


            foreach (var file in files)
            {
                var imagePath = ImageHelper.Save(file);
                CarImage carImage = new() { CarId = carImageAddDto.CarId, ImagePath = imagePath };
               await _carImageDal.AddAsync(carImage);
            }
            return new SuccessResult(Messages.Added);
        }
        public IResult Delete(CarImageDto carImageDto)
        {
            var carImage = _mapper.Map<CarImage>(carImageDto);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImageUpdateDto carImageUpdateDto, IFormFile[] files)
        {
            IResult result = BusinessRules.Run(CheckIfImageCountOfCarCorrect(carImageUpdateDto.CarId, files),
                                               CheckIfMultipleImageUploadLimited(files),
                                               CheckIfCarImageNullOrEmpty(carImageUpdateDto, files));
            if (result != null)
                return result;

            foreach (var file in files)
            {
                var imagePath = ImageHelper.Save(file);
                CarImage carImage = new() { CarId = carImageUpdateDto.CarId, ImagePath = imagePath };
                _carImageDal.Update(carImage);
            }
            return new SuccessResult();
        }

        //Query
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

    
        //Business Rules
        private IResult CheckIfImageCountOfCarCorrect(int carId,IFormFile[] files)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            var totalImageCount = result + files.Length;
            if (totalImageCount > 5)
            {
                return new ErrorResult(Messages.CarImagesLimitExceeded);
            }
            return new SuccessResult();
        }
        private IResult CheckIfMultipleImageUploadLimited(IFormFile[] files)
        {
            if(files.Length > 5)
            {
                return new ErrorResult(Messages.CarImagesLimitExceeded);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarImageNullOrEmpty(CarImageAddDto carImageAddDto, IFormFile[] files)
        {
            if (files.Length == 0)
            {
                var carImage = _mapper.Map<CarImage>(carImageAddDto);
                carImage.ImagePath = "default.jpg";
                _carImageDal.Add(carImage);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarImageNullOrEmpty(CarImageUpdateDto carImageUpdateDto, IFormFile[] files)
        {
            if (files.Length == 0)
            {
                var carImage = _mapper.Map<CarImage>(carImageUpdateDto);
                carImage.ImagePath = "default.jpg";
                _carImageDal.Add(carImage);
            }
            return new SuccessResult();
        }
    }
}

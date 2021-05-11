﻿using Business.Abstract;
using Business.BusinessAspects;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        //[SecuredOperation("admin,car-add")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarValidator))]
        public async Task<IResult> AddAsync(Car car)
        {
            await _carDal.AddAsync(car);
            return new SuccessResult();
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            var data=_carDal.GetAll();
            return new SuccessDataResult<List<Car>>(data);
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

        public IDataResult<Task<List<Car>>> GetAllAsync()
        {
            var data = _carDal.GetAllAsync();
            return new SuccessDataResult<Task<List<Car>>>(data);
        }

        public IDataResult<List<Car>> GetAllBySearch(string search)
        {
             var data= _carDal.GetAll(x => x.Name.ToLower().Contains(search));
            return new SuccessDataResult<List<Car>>(data);
        }
    }
}
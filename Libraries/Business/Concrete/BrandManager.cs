﻿using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        IMapper _mapper;
        public BrandManager(IBrandDal brandDal, IMapper mapper)
        {
            _brandDal = brandDal;
            _mapper = mapper;
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        //[PerformanceAspect(5)]
        public IResult Add(BrandAddDto brandAddDto)
        {
            var brand = _mapper.Map<Brand>(brandAddDto);
            IResult result= BusinessRules.Run(CheckIfBrandNameExists(brand.Name));
            if (result!=null)
            {
                return result;
            }
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<BrandDto>> GetAll()
        {
            var brands = _brandDal.GetAll();
            var brandsDto = _mapper.Map<List<BrandDto>>(brands);
            return new SuccessDataResult<List<BrandDto>>(brandsDto);
        }

        public async Task<IDataResult<List<BrandDto>>> GetAllAsync()
        {
            var brands = await _brandDal.GetAllAsync();
            var brandsDto = _mapper.Map<List<BrandDto>>(brands);
            return new SuccessDataResult<List<BrandDto>>(brandsDto);
        }

        public IDataResult<BrandDto> GetById(int brandId)
        {
            var brand = _brandDal.Get(b => b.Id == brandId);
            var brandDto = _mapper.Map<BrandDto>(brand);
            return new SuccessDataResult<BrandDto>(brandDto);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(BrandDto brandDto)
        {
            var brand = _mapper.Map<Brand>(brandDto);
            _brandDal.Update(brand);
            return new SuccessResult();
        }

        public IResult CheckIfBrandNameExists(string brandName)
        {
            var result = _brandDal.GetAll(b => b.Name == brandName).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        //TODO: Örnek Transaction Kullanımı
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Brand brand)
        {
            _brandDal.Update(brand);
            _brandDal.Add(brand);
            return new SuccessResult(Messages.ProductUpdated);
        }

       
    }
}

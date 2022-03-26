using AutoMapper;
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
using Entities.Dtos.Brand;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandRepository _brandRepository;
        IMapper _mapper;
        public BrandManager(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
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
            _brandRepository.Add(brand);
            return new SuccessResult(Messages.Added);
        }
        public async Task<IResult> AddAsync(BrandAddDto brandAddDto)
        {
            var brand = _mapper.Map<Brand>(brandAddDto);
            await _brandRepository.AddAsync(brand);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(BrandDto brandDto)
        {
            var brand = _mapper.Map<Brand>(brandDto);
            _brandRepository.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<List<BrandDto>> GetAll()
        {
            var brands = _brandRepository.GetAll();
            var brandsDto = _mapper.Map<List<BrandDto>>(brands);
            return new SuccessDataResult<List<BrandDto>>(brandsDto);
        }
        public async Task<IDataResult<List<BrandDto>>> GetAllAsync()
        {
            var brands = await _brandRepository.GetAllAsync();
            var brandsDto = _mapper.Map<List<BrandDto>>(brands);
            return new SuccessDataResult<List<BrandDto>>(brandsDto);
        }
        public IDataResult<BrandDto> GetById(int brandId)
        {
            var brand = _brandRepository.Get(b => b.Id == brandId);
            var brandDto = _mapper.Map<BrandDto>(brand);
            return new SuccessDataResult<BrandDto>(brandDto);
        }
        public async Task<IDataResult<BrandDto>> GetByIdAsync(int brandId)
        {
            var brand = await _brandRepository.GetAsync(x => x.Id == brandId);
            var brandDto = _mapper.Map<BrandDto>(brand);
            return new SuccessDataResult<BrandDto>(brandDto);
        }

  
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(BrandUpdateDto brandDto)
        {
            var brand = _mapper.Map<Brand>(brandDto);
            _brandRepository.Update(brand);
            return new SuccessResult(Messages.Updated);
        }


        //Business Rules
        public IResult CheckIfBrandNameExists(string brandName)
        {
            var result = _brandRepository.GetAll(b => b.Name == brandName).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        //Transaction
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Brand brand)
        {
            _brandRepository.Update(brand);
            _brandRepository.Add(brand);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}

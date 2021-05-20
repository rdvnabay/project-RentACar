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
        public BrandManager(
            IBrandDal brandDal,
            IMapper mapper)
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
        public IDataResult<List<Brand>> GetAll()
        {
            var data = _brandDal.GetAll();
            return new SuccessDataResult<List<Brand>>(data);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            var data = _brandDal.Get(b => b.Id == brandId);
            return new SuccessDataResult<Brand>(data);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
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

        public  IDataResult<Task<List<Brand>>> GetAllAsync()
        {
            var data = _brandDal.GetAllAsync();
            return new SuccessDataResult<Task<List<Brand>>>(data);
        }
    }
}

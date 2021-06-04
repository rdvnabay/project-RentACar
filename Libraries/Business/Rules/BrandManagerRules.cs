﻿using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System.Linq;

namespace Business.Rules
{
    public class BrandManagerRules
    {
        private IBrandDal _brandDal;
        public BrandManagerRules(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public  IResult CheckIfBrandNameExists(string brandName)
        {
            var result = _brandDal.GetAll(b => b.Name == brandName).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}

﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal:EfEntityRepositoryBase<Color,RentACarDbContext>,IColorDal
    {
        public EfColorDal(RentACarDbContext context) : base(context) { }
    }
}

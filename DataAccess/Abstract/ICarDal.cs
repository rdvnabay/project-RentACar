using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        //List<CarForListDto> GetCarDetails(Expression<Func<CarForListDto,bool>> filter=null);
        CarForListDto GetDetails(int carId);
    }
}

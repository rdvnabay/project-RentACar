using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>,IEntityAsyncRepository<Car>
    {
        CarDto GetDetails(int carId);
        List<CarDto> GetAllBySearch(string search);
      //  List<CarDto> GetAllBySearch(Expression<Func<CarDto,bool>> search);
        List<CarDto> GetAllByBrandIdAndColorId(int brandId, int colorId);
    }
}

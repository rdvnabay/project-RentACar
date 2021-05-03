using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<Car> GetById(int carId);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarForListDto>> GetAllDto();

        IDataResult<CarForListDto> GetDetails(int carId);
        IDataResult<List<Car>> GetAllByBrand(int brandId);
        IDataResult<List<Car>>GetAllByColor(int colorId);
    }
}

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

        IDataResult<List<CarForDetailDto>> GetCarDetails();
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
    }
}

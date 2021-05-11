using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImage carImage);
        IResult Update(CarImage carImage);
        IResult Delete(CarImage carImage);

        IDataResult<CarImage> GetByCarId(int carId);
        IDataResult<List<CarImage>> GetImagesByCarId(int carId);
    }
}

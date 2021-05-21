using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImage carImage);
        IResult Update(CarImageDto carImageDto);
        IResult Delete(CarImageDto carImageDto);

        IDataResult<CarImageDto> GetByCarId(int carId);
        IDataResult<List<CarImageDto>> GetImagesByCarId(int carId);
    }
}

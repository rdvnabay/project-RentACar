using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos.CarImage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImageAddDto carImageAddDto);
        Task<IResult> AddAsync(CarImageAddDto carImageAddDto);
        IResult Update(CarImageDto carImageDto);
        Task<IResult> UpdateAsync(CarImageDto carImageDto);
        IResult Delete(CarImageDto carImageDto);
        Task<IResult> DeleteAsync(CarImageDto carImageDto);
        IDataResult<List<CarImageDto>> GetAll();
        Task<IDataResult<List<CarImageDto>>> GetAllAsync();
        IDataResult<CarImageDto> GetByCarId(int carId);
        Task<IDataResult<CarImageDto>> GetByCarIdAsync(int carId);
        IDataResult<List<CarImageDto>> GetImagesByCarId(int carId);
        Task<IDataResult<List<CarImageDto>>> GetImagesByCarIdAsync(int carId);
        Task<IResult> DeleteByIdAsync(int carId);
    }
}

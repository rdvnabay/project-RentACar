using Core.Utilities.Results.Abstract;
using Entities.Dtos.CarImage;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        //Command
        IResult Add(CarImageAddDto carImageAddDto, IFormFile[] files);
        Task<IResult> AddAsync(CarImageAddDto carImageAddDto, IFormFile[] files);
        IResult Delete(CarImageDto carImageDto);
        IResult Update(CarImageUpdateDto carImageUpdateDto, IFormFile[] files);

        //Query
        IDataResult<List<CarImageDto>> GetAll();
        Task<IDataResult<List<CarImageDto>>> GetAllAsync();
        IDataResult<CarImageDto> GetByCarId(int carId);
        Task<IDataResult<CarImageDto>> GetByCarIdAsync(int carId);
        IDataResult<List<CarImageDto>> GetImagesByCarId(int carId);
        Task<IDataResult<List<CarImageDto>>> GetImagesByCarIdAsync(int carId);
    }
}

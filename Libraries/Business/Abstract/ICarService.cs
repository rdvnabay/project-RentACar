using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos.Car;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        //Command
        IResult Add(CarAddDto carAddDto);
        Task<IResult> AddAsync(CarAddDto carAddDto);
        IResult DeleteById(int carId);
        IResult Update(CarUpdateDto carUpdateDto);
       
        //Query
        IDataResult<CarDto> GetById(int carId);
        Task<IDataResult<CarDto>> GetByIdAsync(int carId);
        IDataResult<List<CarDto>> GetAll();
        Task<IDataResult<List<CarDto>>> GetAllAsync();
        IDataResult<CarDto> GetDetail(int carId);
        Task<IDataResult<CarDto>> GetDetailAsync(int carId);
        IDataResult<List<CarDto>> GetAllByBrand(int brandId);
        Task<IDataResult<List<CarDto>>> GetAllByBrandAsync(int brandId);
        IDataResult<List<CarDto>>GetAllByColor(int colorId);
        Task<IDataResult<List<CarDto>>> GetAllByColorAsync(int colorId);
        IDataResult<List<CarDto>>GetAllBySearch(string search);
        Task<IDataResult<List<CarDto>>> GetAllBySearchAsync(string search);
        IDataResult<List<CarDto>> GetAllByBrandIdAndColorId(int brandId, int colorId);
        Task<IDataResult<List<CarDto>>> GetAllByBrandIdAndColorIdAsync(int brandId, int colorId);

    }
}

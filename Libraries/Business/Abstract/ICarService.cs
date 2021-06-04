using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos.Car;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(CarAddDto carAddDto);
        Task<IResult> AddAsync(CarAddDto carAddDto);
        IResult Update(Car car);
        Task<IResult> UpdateAsync(CarUpdateDto carUpdateDto);
        IResult Delete(Car car);
        Task<IResult> DeleteByIdAsync(int carId);
        IDataResult<Car> GetById(int carId);
        IDataResult<List<CarDto>> GetAll();
        Task<IDataResult<List<CarDto>>> GetAllAsync();

        IDataResult<CarDto> GetDetails(int carId);
        IDataResult<List<Car>> GetAllByBrand(int brandId);
        IDataResult<List<Car>>GetAllByColor(int colorId);
        IDataResult<List<CarDto>>GetAllBySearch(string search);
        IDataResult<List<CarDto>> GetAllByBrandIdAndColorId(int brandId, int colorId);
    }
}

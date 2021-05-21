using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(CarAddDto carAddDto);
        Task<IResult> AddAsync(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<Car> GetById(int carId);
        IDataResult<List<CarDto>> GetAll();
        Task<IDataResult<List<Car>>> GetAllAsync();

        IDataResult<CarDto> GetDetails(int carId);
        IDataResult<List<Car>> GetAllByBrand(int brandId);
        IDataResult<List<Car>>GetAllByColor(int colorId);
        IDataResult<List<Car>>GetAllBySearch(string search);
    }
}

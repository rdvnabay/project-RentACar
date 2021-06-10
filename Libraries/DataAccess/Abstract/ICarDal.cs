using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.Car;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>,IEntityAsyncRepository<Car>
    {
        List<CarDto> GetAllBySearch(string search);
      //  List<CarDto> GetAllBySearch(Expression<Func<CarDto,bool>> search);
        List<CarDto> GetAllByBrandIdAndColorId(int brandId, int colorId);
        Task<List<CarDto>> GetAllDto();
        CarDto GetCarWithBrandNameAndColorName(int carId);
        Task<CarDto> GetCarWithBrandNameAndColorNameAsync(int carId);
        Task<CarDetailDto> GetCarWithBrandNameAndColorNameAndImagesAsync(int carId);
        List<CarDto> GetAllCarWithBrandNameAndColorName();
        Task<List<CarDto>> GetAllCarWithBrandNameAndColorNameAsync();
    }
}

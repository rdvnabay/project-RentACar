using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(BrandAddDto brandAddDto);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
        IDataResult<Brand> GetById(int brandId);
        IDataResult<List<BrandDto>> GetAll();
        IDataResult<Task<List<Brand>>> GetAllAsync();
    }
}

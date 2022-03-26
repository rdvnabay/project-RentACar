using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.Brand;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(BrandAddDto brandAddDto);
        Task<IResult> AddAsync(BrandAddDto brandAddDto);
        IResult Delete(BrandDto brandDto);
        IDataResult<List<BrandDto>> GetAll();
        Task<IDataResult<List<BrandDto>>> GetAllAsync();
        IDataResult<BrandDto> GetById(int brandId);
        Task<IDataResult<BrandDto>> GetByIdAsync(int brandId);
        IResult Update(BrandUpdateDto brandDto);
    }
}

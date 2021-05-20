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
        IResult Delete(BrandDto brandDto);
        IDataResult<List<BrandDto>> GetAll();
        Task<IDataResult<List<BrandDto>>> GetAllAsync();
        IDataResult<BrandDto> GetById(int brandId);
        IResult Update(BrandDto brandDto);


    }
}

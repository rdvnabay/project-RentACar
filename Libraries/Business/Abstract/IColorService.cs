using Core.Utilities.Results.Abstract;
using Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(ColorAddDto colorAddDto);
        Task<IResult> AddAsync(ColorAddDto colorAddDto);
        IResult Delete(ColorDto colorDto);
        Task<IResult> DeleteAsync(ColorDto colorDto);
        IDataResult<List<ColorDto>> GetAll();
        Task<IDataResult<List<ColorDto>>> GetAllAsync();
        IDataResult<ColorDto> GetById(int colorId);
        Task<IDataResult<ColorDto>> GetByIdAsync(int colorId);
        IResult Update(ColorDto colorDto);
        Task<IResult>UpdateAsync(ColorDto colorDto);
    }
}

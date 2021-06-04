using Core.Utilities.Results.Abstract;
using Entities.Dtos.Color;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(ColorAddDto colorAddDto);
        Task<IResult> AddAsync(ColorAddDto colorAddDto);
        IResult DeleteById(int colorId);
        Task<IResult> DeleteByIdAsync(int colorId);
        IDataResult<List<ColorDto>> GetAll();
        Task<IDataResult<List<ColorDto>>> GetAllAsync();
        IDataResult<ColorDto> GetById(int colorId);
        Task<IDataResult<ColorDto>> GetByIdAsync(int colorId);
        IResult Update(ColorDto colorDto);
        Task<IResult>UpdateAsync(ColorUpdateDto colorUpdateDto);
    }
}

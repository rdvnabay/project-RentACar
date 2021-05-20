using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(ColorAddDto colorAddDto);
        IResult Delete(Color color);
        IDataResult<List<ColorDto>> GetAll();
        IDataResult<Task<List<Color>>> GetAllAsync();
        IDataResult<Color> GetById(int colorId);
        IResult Update(Color color);

     
    }
}

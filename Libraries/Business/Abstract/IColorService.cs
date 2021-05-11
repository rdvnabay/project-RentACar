using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
        IDataResult<Color> GetById(int colorId);
        IDataResult<List<Color>> GetAll();
        IDataResult<Task<List<Color>>> GetAllAsync();
    }
}

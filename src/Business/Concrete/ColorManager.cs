using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Color;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorRepository _colorDal;
        private IMapper _mapper;

        public ColorManager(
            IColorRepository colorDal,
            IMapper mapper)
        {
            _colorDal = colorDal;
            _mapper = mapper;
        }

        //[SecuredOperation("admin,color-add")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(ColorAddDto colorAddDto)
        {
            var color = _mapper.Map<Color>(colorAddDto);
            _colorDal.Add(color);
            return new SuccessResult();
        }
        public async Task<IResult> AddAsync(ColorAddDto colorAddDto)
        {
            var color = _mapper.Map<Color>(colorAddDto);
            await _colorDal.AddAsync(color);
            return new SuccessResult(Messages.Added);
        }
        public IResult DeleteById(int colorId)
        {
            var color = _colorDal.Get(x => x.Id == colorId);
            _colorDal.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<List<ColorDto>> GetAll()
        {
            var colors= _colorDal.GetAll();
            var colorsDto = _mapper.Map<List<ColorDto>>(colors);
            return new SuccessDataResult<List<ColorDto>>(colorsDto);
        }
        public async Task<IDataResult<List<ColorDto>>> GetAllAsync()
        {
            var colors = await _colorDal.GetAllAsync();
            var colorsDto = _mapper.Map<List<ColorDto>>(colors);
            return new SuccessDataResult<List<ColorDto>>(colorsDto);
        }
        public IDataResult<ColorDto> GetById(int colorId)
        {
            var color= _colorDal.Get(c => c.Id == colorId);
            var colorDto = _mapper.Map<ColorDto>(color);
            return new SuccessDataResult<ColorDto>(colorDto);
        }
        public async Task<IDataResult<ColorDto>> GetByIdAsync(int colorId)
        {
            var color = await _colorDal.GetByIdAsync(colorId);
            var colorDto = _mapper.Map<ColorDto>(color);
            return new SuccessDataResult<ColorDto>(colorDto);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(ColorUpdateDto colorDto)
        {
            var color = _mapper.Map<Color>(colorDto);
            _colorDal.Update(color);
            return new SuccessResult();
        }
    }
}

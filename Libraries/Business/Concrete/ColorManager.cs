﻿using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;
        private IMapper _mapper;

        public ColorManager(
            IColorDal colorDal,
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

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<List<ColorDto>> GetAll()
        {
            var colors= _colorDal.GetAll();
            var colorsDto = _mapper.Map<List<ColorDto>>(colors);
            return new SuccessDataResult<List<ColorDto>>(colorsDto);
        }

        public IDataResult<Task<List<Color>>> GetAllAsync()
        {
            var data = _colorDal.GetAllAsync();
            return new SuccessDataResult<Task<List<Color>>>(data);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            var data= _colorDal.Get(c => c.Id == colorId);
            return new SuccessDataResult<Color>(data);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult();
        }
    }
}

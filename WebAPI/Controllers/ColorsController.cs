using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private IColorService _colorService;
        private IMapper _mapper;
        public ColorsController(
            IColorService colorService,
            IMapper mapper)
        {
            _colorService = colorService;
            _mapper = mapper;
        }

        //Methods
        [HttpGet("get")]
        public IActionResult Get(int colorId)
        {
            var data = _colorService.GetById(colorId);
            return Ok(data.Data);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var data = _colorService.GetAll().Data;
            var result = _mapper.Map<List<ColorListDto>>(data);
            if (result.Count>0)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            _colorService.Add(color);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update(Color color)
        {
            _colorService.Update(color);
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Color color)
        {
            _colorService.Delete(color);
            return Ok();
        }
    }
}

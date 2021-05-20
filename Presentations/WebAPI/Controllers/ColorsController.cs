﻿using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private IColorService _colorService;
        public ColorsController(
            IColorService colorService)
        {
            _colorService = colorService;
        }

        //Methods
        [HttpPost("add")]
        public IActionResult Add(ColorAddDto colorAddDto)
        {
            var result= _colorService.Add(colorAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Color color)
        {
            _colorService.Delete(color);
            return Ok();
        }

        [HttpGet("get")]
        public IActionResult Get(int colorId)
        {
            var data = _colorService.GetById(colorId);
            return Ok(data.Data);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Color color)
        {
            _colorService.Update(color);
            return Ok();
        }
    }
}

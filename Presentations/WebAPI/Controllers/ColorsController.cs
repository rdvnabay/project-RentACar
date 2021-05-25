using Business.Abstract;
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
            var result = _colorService.Add(colorAddDto);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(ColorDto colorDto)
        {
            var result = _colorService.Delete(colorDto);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int colorId)
        {
            var result = _colorService.GetById(colorId);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(ColorDto colorDto)
        {
            var result = _colorService.Update(colorDto);
            return result.Success
              ? Ok(result)
              : BadRequest(result);
        }
    }
}

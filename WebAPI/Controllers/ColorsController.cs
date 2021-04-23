using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private IColorService _colorService;
        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
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

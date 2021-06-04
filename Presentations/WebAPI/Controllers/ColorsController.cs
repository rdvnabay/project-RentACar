using Business.Abstract;
using Entities.Dtos.Color;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Add(ColorAddDto colorAddDto)
        {
            var result = await _colorService.AddAsync(colorAddDto);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(ColorDto colorDto)
        {
            var result = await _colorService.DeleteAsync(colorDto);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(int colorId)
        {
            var result = await _colorService.GetByIdAsync(colorId);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _colorService.GetAllAsync();
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ColorUpdateDto colorUpdateDto)
        {
            var result = await _colorService.UpdateAsync(colorUpdateDto);
            return result.Success
              ? Ok(result)
              : BadRequest(result);
        }
    }
}

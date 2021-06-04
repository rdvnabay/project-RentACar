using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CarImageAddDto carImageAddDto)
        {
            var result = await _carImageService.AddAsync(carImageAddDto);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }

        [HttpPost("delete/{carId}")]
        public IActionResult Delete(int carId)
        {
            var carImage = _carImageService.GetByCarId(carId).Data;
            var result = _carImageService.Delete(carImage);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _carImageService.GetAllAsync();
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpGet("images/{carId}")]
        public IActionResult GetImagesByCarId(int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] CarImageDto carImageDto)
        {
            var result = await _carImageService.UpdateAsync(carImageDto);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }
    }
}

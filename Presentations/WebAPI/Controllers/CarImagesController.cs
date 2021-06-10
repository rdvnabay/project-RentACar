using Business.Abstract;
using Entities.Dtos.CarImage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<IActionResult> Add(CarImageAddDto carImageAddDto, IFormFile[] files)
        {
            var result = await _carImageService.AddAsync(carImageAddDto, files);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }

        [HttpDelete("delete/{carId}")]
        public async Task<IActionResult> Delete(int carId)
        {
            var result = await _carImageService.DeleteByIdAsync(carId);
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
        public async Task<IActionResult> GetImagesByCarId(int carId)
        {
            var result = await _carImageService.GetImagesByCarIdAsync(carId);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] CarImageUpdateDto carImageUpdateDto,IFormFile[] files)
        {
            var result = await _carImageService.UpdateAsync(carImageUpdateDto, files);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }
    }
}

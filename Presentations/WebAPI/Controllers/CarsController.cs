using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CarAddDto carAddDto)
        {
            var result = await _carService.AddAsync(carAddDto);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int carId)
        {
            var result = await _carService.DeleteByIdAsync(carId);
            return result.Success
              ? Ok(result)
              : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _carService.GetAllAsync();
            return result.Success
                          ? Ok(result)
                          : BadRequest(result);
        }

        [HttpGet("getallbybrand")]
        public IActionResult GetAllByBrand(int brandId)
        {
            var data = _carService.GetAllByBrand(brandId);
            return Ok(data.Data);
        }

        [HttpGet("getallbycolor")]
        public IActionResult GetAllByColor(int colorId)
        {
            var result = _carService.GetAllByColor(colorId);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }

        [HttpGet("getdetails")]
        public IActionResult GetDetails(int carId)
        {
            var result = _carService.GetDetails(carId);
            return result.Success
                 ? Ok(result)
                 : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
    }
}

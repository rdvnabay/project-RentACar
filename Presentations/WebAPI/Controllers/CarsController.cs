using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Add(CarAddDto carAddDto)
        {
            var result = _carService.Add(carAddDto);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            return result.Success
              ? Ok(result)
              : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
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

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
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            _carService.Delete(car);
            return Ok();
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbybrand")]
        public IActionResult GetAllByBrand(int brandId)
        {
            var data= _carService.GetAllByBrand(brandId);
            return Ok(data.Data);
        }

        [HttpGet("getallbycolor")]
        public IActionResult GetAllByColor(int colorId)
        {
            var result = _carService.GetAllByColor(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }  

        [HttpGet("getdetails")]
        public IActionResult GetDetails(int carId)
        {
            var result = _carService.GetDetails(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            _carService.Update(car);
            return Ok();
        }

      
    }
}

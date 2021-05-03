using Business.Abstract;
using Entities.Concrete;
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
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
           var result= _carService.Add(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            _carService.Update(car);
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            _carService.Delete(car);
            return Ok();
        }
    }
}

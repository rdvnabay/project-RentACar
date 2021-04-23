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
        
        [HttpGet("get")]
        public IActionResult Get(int carId)
        {
            var data= _carService.GetById(carId);
            return Ok(data.Data);
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

        [HttpGet("detail")]
        public IActionResult Detail()
        {
            var data = _carService.GetCarDetails();
            return Ok(data);
        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            _carService.Add(car);
            return Ok();
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

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

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

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

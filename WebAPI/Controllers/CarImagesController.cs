using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Add(CarImage carImage)
        {
            var data = _carImageService.Add(carImage);
            return Ok(data);
        }

        [HttpGet("images/{carId}")]
        public IActionResult GetImagesByCarId(int carId)
        {
            var data = _carImageService.GetImagesByCarId(carId);
            return Ok(data);
        }

        [HttpPost("remove/{carId}")]
        public IActionResult Delete(int carId)
        {
            var data = _carImageService.GetByCarId(carId).Data;
            _carImageService.Delete(data);
            return Ok(data);
        }
    }
}

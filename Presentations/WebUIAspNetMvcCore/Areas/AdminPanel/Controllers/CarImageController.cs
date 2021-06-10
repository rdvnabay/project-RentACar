using Business.Abstract;
using Entities.Dtos.CarImage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUIAspNetMvcCore.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CarImageController : Controller
    {
        private ICarImageService _carImageService;

        public CarImageController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CarImageAddDto carImageAddDto,IFormFile[] files)
        {
            var result = _carImageService.Add(carImageAddDto, files);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }
        public IActionResult Edit(int carImageId)
        {
            var carImage = _carImageService.GetByCarId(carImageId);
            return View(carImage);
        }

        [HttpPost]
        public IActionResult Edit(CarImageUpdateDto carImageUpdateDto, IFormFile[] files)
        {
            var result = _carImageService.Update(carImageUpdateDto, files);
            return result.Success 
                ? Ok(result) 
                : BadRequest();
        }
    }
}

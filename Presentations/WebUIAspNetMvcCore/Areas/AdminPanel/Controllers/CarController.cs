using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.Car;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebUIAspNetMvcCore.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CarController : Controller
    {
        private ICarService _carService;
        private ICarImageService _carImageService;
        private IMapper _mapper;
        public CarController(
            ICarService carService,
            ICarImageService carImageService,
            IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
            _carImageService = carImageService;
        }

        //Actions
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarAddDto carAddDto, IFormFile[] files)
        {

            if (!ModelState.IsValid)
            {
                return View(carAddDto);
            }
            await _carService.AddAsync(carAddDto);
            foreach (var file in files)
            {
                var extention = Path.GetExtension(file.FileName);
                var fileName = string.Format($"{DateTime.Now.Ticks}{extention}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\panel\\img", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                var image = new CarImage
                {
                    CarId = 1,
                    ImagePath = fileName
                };
                //TODO: BAKILACAK
                //_carImageService.Add(image);
            }
            return RedirectToAction("List", "Car");
        }

        public IActionResult Delete(int carId)
        {
            var result = _carService.GetById(carId);
            if (result.Success)
            {
               // _carService.Delete(result.Data);
            }
            return RedirectToAction("List", "Car");
        }

        public IActionResult Detail(int carId)
        {
            var model = _carService.GetById(carId).Data;
            return View(model);
        }

        public IActionResult Edit(int carId)
        {
            var model = _carService.GetById(carId).Data;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Car car)
        {
            //var result = _carService.Update(car);
            //if (result.Success)
            //{
            //    return RedirectToAction("List", "Car");
            //}
            return View();
        }

        public IActionResult GetAllByBrand(int brandId)
        {
            var result = _carService.GetAllByBrand(brandId);
            if (result.Success)
            {
                return View(result.Data);
            }
            return RedirectToAction("List", "Brand");
        }

        public IActionResult GetAllByColor(int colorId)
        {
            var result = _carService.GetAllByColor(colorId);
            if (result.Success)
            {
                return View(result.Data);
            }
            return RedirectToAction("List", "Color");
        }

        public IActionResult List(string search)
        {
            var result = _carService.GetAllBySearch(search);
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        //public IActionResult List(int brandId, int colorId)
        //{
        //    var result = _carService.GetAllByBrandIdAndColorId(brandId,colorId);
        //    if (result.Success)
        //    {
        //        return View(result.Data);
        //    }
        //    return View();
        //}
    }
}

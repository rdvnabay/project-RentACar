using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public IActionResult List(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                var data = _carService.GetAll().Data;
                var model = _mapper.Map<List<CarForListDto>>(data);
                return View(model);
            }
            else
            {
                var data = _carService.GetAllBySearch(search).Data;
                var model = _mapper.Map<List<CarForListDto>>(data);
                return View(model);
            }
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Car car, IFormFile[] files)
        {

            if (!ModelState.IsValid)
            {
                return View(car);
            }
                _carService.Add(car);
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
                        CarId = car.Id,
                        Date = DateTime.Now,
                        ImagePath = fileName
                    };
                    _carImageService.Add(image);
                }
                return RedirectToAction("List", "Car");
        }

        public IActionResult Delete(int carId)
        {
            var result = _carService.GetById(carId);
            if (result.Success)
            {
                _carService.Delete(result.Data);
            }
            return RedirectToAction("List", "Car");
        }

        public IActionResult Edit(int carId)
        {
            var model = _carService.GetById(carId).Data;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return RedirectToAction("List", "Car");
            }
            return View(result);
        }

        public IActionResult Detail(int carId)
        {
            var model = _carService.GetById(carId).Data;
            return View(model);
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
    }
}

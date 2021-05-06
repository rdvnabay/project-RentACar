using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebUIAspNetMvcCore.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CarController : Controller
    {
        private ICarService _carService;
        private IMapper _mapper;
        public CarController(
            ICarService carService,
            IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        public IActionResult List()
        {
            var data = _carService.GetAll().Data;
            var model = _mapper.Map<List<CarForListDto>>(data);
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Car car)
        {
            _carService.Add(car);
            return RedirectToAction("List", "Car");
        }

        public IActionResult Delete(int carId)
        {
            var result = _carService.GetById(carId);
            if (result.Success)
            {
                _carService.Delete(result.Data);
                return RedirectToAction("List", "Car");
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

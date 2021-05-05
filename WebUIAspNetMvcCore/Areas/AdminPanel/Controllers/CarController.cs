using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIAspNetMvcCore.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CarController : Controller
    {
        private ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult List()
        {
            var result = _carService.GetAllDto().Data;
            return View(result);
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
    }
}

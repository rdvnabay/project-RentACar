using Business.Abstract;
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
            var model = _carService.Add(car);
            return View(model);
        }
    }
}

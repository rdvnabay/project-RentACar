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
    public class ColorController : Controller
    {
        private IColorService _colorService;
        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        public IActionResult List()
        {
           var model= _colorService.GetAll().Data;
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);
            if (result.Success)
            {
                return RedirectToAction("Index", "Color");
            }
            return View(result);
        }
    }
}

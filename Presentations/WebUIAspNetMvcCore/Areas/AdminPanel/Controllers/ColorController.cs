using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.Color;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUIAspNetMvcCore.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ColorController : Controller
    {
        private IColorService _colorService;
        public ColorController(
            IColorService colorService)
        {
            _colorService = colorService;
        }

        //Actions
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ColorAddDto colorAddDto)
        {
            var result = _colorService.Add(colorAddDto);
            if (result.Success)
            {
                return RedirectToAction("List", "Color");
            }
            return View(result);
        }

        public IActionResult Delete(int colorId)
        {
            var result = _colorService.GetById(colorId);
            if (result.Success)
            {
                _colorService.Delete(result.Data);
            }
            return RedirectToAction("List", "Color");
        }

        public IActionResult Edit(int colorId)
        {
            var model = _colorService.GetById(colorId).Data;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ColorDto colorDto)
        {
            var result = _colorService.Update(colorDto);
            if (result.Success)
            {
                return RedirectToAction("List", "Color");
            }
            return View(result);
        }

        public IActionResult List()
        {
            var model = _colorService.GetAll().Data;
            return View(model);
        }
    }
}

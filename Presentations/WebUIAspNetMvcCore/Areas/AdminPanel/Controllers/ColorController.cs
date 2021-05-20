using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUIAspNetMvcCore.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ColorController : Controller
    {
        private IColorService _colorService;
        private IMapper _mapper;
        public ColorController(
            IColorService colorService,
            IMapper mapper)
        {
            _colorService = colorService;
            _mapper = mapper;
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

        public async Task<IActionResult> List()
        {
            var data = await _colorService.GetAllAsync().Data;
            var model = _mapper.Map<List<ColorDto>>(data);
            return View(model);
        }
    }
}

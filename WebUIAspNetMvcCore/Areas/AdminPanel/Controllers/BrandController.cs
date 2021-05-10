using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebUIAspNetMvcCore.Areas.Admin.Controllers
{
    [Area("AdminPanel")]
    public class BrandController : Controller
    {
        private IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IActionResult> List()
        {
            var model = await _brandService.GetAllAsync().Data;
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Brand brand)
        {
            var result = _brandService.Add(brand);
            if (result.Success)
            {
                return RedirectToAction("List", "Brand");
            }
            return View(result);
        }

        public IActionResult Edit(int brandId)
        {
            var model = _brandService.GetById(brandId).Data;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
           var result= _brandService.Update(brand);
            if (result.Success)
            {
                return RedirectToAction("List", "Brand");
            }
            return View(result);
        }

        public IActionResult Delete(int brandId)
        {
            var result = _brandService.GetById(brandId);
            if (result.Success)
            {
                _brandService.Delete(result.Data);
            }
            return RedirectToAction("List", "Brand");
        }
    }
}

using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult List()
        {
            var model = _brandService.GetAll().Data;
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Brand brand)
        {
            _brandService.Add(brand);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}

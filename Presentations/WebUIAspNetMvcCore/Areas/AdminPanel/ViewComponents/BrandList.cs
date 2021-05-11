using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebUIAspNetMvcCore.Areas.AdminPanel.Models;

namespace WebUIAspNetMvcCore.Areas.AdminPanel.ViewComponents
{
    public class BrandList : ViewComponent
    {
        private IBrandService _brandService;
        public BrandList(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public IViewComponentResult Invoke()
        {
            int brandId = 0;
            var model = _brandService.GetAll().Data;
            return View(new BrandListModel
            {
                BrandId = brandId,
                Brands = model
            });
        }
    }
}

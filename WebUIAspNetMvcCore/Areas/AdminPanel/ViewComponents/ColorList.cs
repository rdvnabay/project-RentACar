using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebUIAspNetMvcCore.Areas.AdminPanel.Models;

namespace WebUIAspNetMvcCore.Areas.AdminPanel.ViewComponents
{
    public class ColorList : ViewComponent
    {
        private IColorService _colorService;
        public ColorList(IColorService colorService)
        {
            _colorService = colorService;
        }
        public IViewComponentResult Invoke(int colorId)
        {
            var model = _colorService.GetAll().Data;
            return View(new ColorListModel
            {
                ColorId=colorId,
                Colors=model
            });
        }
    }
}

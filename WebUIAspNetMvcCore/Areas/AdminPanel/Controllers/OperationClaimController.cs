using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUIAspNetMvcCore.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class OperationClaimController : Controller
    {
        private IOperationClaimService _operationClaimService;
        public OperationClaimController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }

        public IActionResult List()
        {
            var model = _operationClaimService.GetAll().Data;
            return View(model);

        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(OperationClaim model)
        {
            _operationClaimService.Add(model);
            return RedirectToAction("GetAll", "OperationClaim");
        }

        //public IActionResult Delete()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult Delete(OperationClaim model)
        {
            _operationClaimService.Delete(model);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}

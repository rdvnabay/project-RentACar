using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIAspNetMvcCore.Areas.AdminPanel.ViewComponents
{
    public class OperationClaimList : ViewComponent
    {
        private IOperationClaimService _operationClaimService;
        public OperationClaimList(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }
        public IViewComponentResult Invoke()
        {
            var model = _operationClaimService.GetAll().Data;
            return View(model);
        }
    }
}

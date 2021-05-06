using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebUIAspNetMvcCore.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class OperationClaimController : Controller
    {
        private IOperationClaimService _operationClaimService;
        private IMapper _mapper;
        public OperationClaimController(
            IOperationClaimService operationClaimService,
            IMapper mapper)
        {
            _operationClaimService = operationClaimService;
            _mapper = mapper;
        }


        public IActionResult List()
        {
            var data = _operationClaimService.GetAll().Data;
            var model = _mapper.Map<List<OperationClaimListDto>>(data);
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

        [HttpPost]
        public IActionResult Delete(OperationClaim model)
        {
            _operationClaimService.Delete(model);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}

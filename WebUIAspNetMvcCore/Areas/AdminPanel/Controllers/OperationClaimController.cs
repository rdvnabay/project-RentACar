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
        public IActionResult Add(OperationClaim operationClaim)
        {
            var result = _operationClaimService.Add(operationClaim);
            if (result.Success)
            {
                return RedirectToAction("List", "OperationClaim");
            }
            return View(result);
        }

        public IActionResult Edit(int operationClaimId)
        {
            var model = _operationClaimService.GetById(operationClaimId).Data;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(OperationClaim operationClaim)
        {
            var result = _operationClaimService.Update(operationClaim);
            if (result.Success)
            {
                return RedirectToAction("List", "OperationClaim");
            }
            return View(operationClaim);
        }

        public IActionResult Delete(int operationClaimId)
        {
            var result = _operationClaimService.GetById(operationClaimId);
            if (result.Success)
            {
                _operationClaimService.Delete(result.Data);
            }
            return RedirectToAction("List", "OperationClaim");
        }
    }
}

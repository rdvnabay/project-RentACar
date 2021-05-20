using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebUIAspNetMvcCore.Areas.AdminPanel.Models;

namespace WebUIAspNetMvcCore.Areas.Admin.Controllers
{
    [Area("AdminPanel")]
    public class BrandController : Controller
    {
        private IBrandService _brandService;
        public BrandController(
            IBrandService brandService)
        {
            _brandService = brandService;
        }

        //Actions
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BrandAddDto brandAddDto)
        {
            //string tokenUrl = Environment.GetEnvironmentVariable("TOKEN_VALIDATE_URL");
            string token = HttpContext.Session.GetString("token");
            HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
          
            var result = _brandService.Add(brandAddDto);
            if (result.Success)
            {
                var alertMessage = new AlertMessage
                {
                    Message = $"{brandAddDto.Name} markası eklendi.",
                    AlertType = "success"
                };
                TempData["alertMessage"] = JsonConvert.SerializeObject(alertMessage);
                //client.GetStringAsync(tokenUrl);
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

        public IActionResult Edit(int brandId)
        {
            var model = _brandService.GetById(brandId).Data;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(BrandDto brandDto)
        {
            var result = _brandService.Update(brandDto);
            if (result.Success)
            {
                return RedirectToAction("List", "Brand");
            }
            return View(result);
        }

        public IActionResult List()
        {
            var data = _brandService.GetAll().Data;
            return View(data);
        }
    }
}

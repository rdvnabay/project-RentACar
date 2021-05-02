using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIAspNetMvcCore.Areas.Admin.Controllers
{
    [Area("AdminPanel")]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserForRegisterDto model)
        {
            var userExist = _authService.UserExists(model.Email);
            //if (!userExist.Success)
            //{
            //    return View(model);
            //}
           var registerResult = _authService.Register(model, model.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserForLoginDto model)
        {
            var userLogin = _authService.Login(model);
            if (!userLogin.Success)
            {
                return View(model);
            }
            var result = _authService.CreateAccessToken(userLogin.Data);
            if (result.Success)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}

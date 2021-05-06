using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIAspNetMvcCore.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserController : Controller
    {
        private IUserService _userService;
        private IAuthService _authService;
        public UserController(
            IUserService userService,
            IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
        public IActionResult Profile(int userId)
        {
            var result = _userService.GetById(userId);
            if (result.Success)
            {
                return View(result.Data);
            }
            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult List()
        {
            var model= _userService.GetAllDto().Data;
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserForRegisterDto model)
        {
            var userExist = _authService.UserExists(model.Email);
            if (!userExist.Success)
            {
                return View(model);
            }
            var registerResult = _authService.Register(model, model.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View(model);
        }
    }
}

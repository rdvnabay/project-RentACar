using AutoMapper;
using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebUIAspNetMvcCore.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserController : Controller
    {
        private IUserService _userService;
        private IAuthService _authService;
        private IMapper _mapper;
        public UserController(
            IUserService userService,
            IAuthService authService,
            IMapper mapper)
        {
            _userService = userService;
            _authService = authService;
            _mapper = mapper;
        }

        //Actions
        public IActionResult Profile(int userId)
        {
            var result = _userService.GetById(userId);
            if (result.Success)
            {
                return View(result.Data);
            }
            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index","Dashboard");
        }

        public IActionResult List()
        {
            var data = _userService.GetAll().Data;
            var model = _mapper.Map<List<UserForListDto>>(data);
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

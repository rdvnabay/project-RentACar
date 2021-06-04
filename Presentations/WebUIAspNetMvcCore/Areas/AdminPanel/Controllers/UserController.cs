using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Dtos.User;
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

        public IActionResult Delete(int userId)
        {
            var result = _userService.GetById(userId);
            if (result.Success)
            {
                _userService.Delete(result.Data);
            }
            return RedirectToAction("List", "User");
        }

        public IActionResult Edit(int userId)
        {
            var model = _userService.GetById(userId).Data;
            return View(model);
        }

        public IActionResult Edit(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return RedirectToAction("List", "User");
            }
            return View(user);
        }

        public IActionResult List()
        {
            var data = _userService.GetAll().Data;
            var model = _mapper.Map<List<UserDto>>(data);
            return View(model);
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Dashboard");
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
    }
}

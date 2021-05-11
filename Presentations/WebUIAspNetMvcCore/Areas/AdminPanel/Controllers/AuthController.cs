using Business.Abstract;
using Core.Extensions;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using WebUIAspNetMvcCore.Services;

namespace WebUIAspNetMvcCore.Areas.Admin.Controllers
{
    [Area("AdminPanel")]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private ITokenSessionService _tokenSessionService;
        public AuthController(
            IAuthService authService,
            ITokenSessionService tokenSessionService
            )
        {
            _authService = authService;
            _tokenSessionService = tokenSessionService;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserForRegisterDto model)
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
                HttpContext.Session.SetString("token", result.Data.Token);
                string token = HttpContext.Session.GetString("token");
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
               
                //TempData["tokenVal"] = HttpContext.Session.GetObject<AccessToken>("token").Token;
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

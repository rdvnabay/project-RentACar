using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get")]
        public IActionResult Get(int userId)
        {
            var data = _userService.GetById(userId);
            return Ok(data.Data);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            _userService.Add(user);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            _userService.Update(user);
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            _userService.Delete(user);
            return Ok();
        }
    }
}

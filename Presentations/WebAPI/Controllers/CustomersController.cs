using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("get")]
        public IActionResult Get(int userId)
        {
            var data = _customerService.GetById(userId);
            return Ok(data.Data);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            _customerService.Add(customer);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            _customerService.Update(customer);
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Customer customer)
        {
            _customerService.Delete(customer);
            return Ok();
        }
    }
}

using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.Customer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Get(int userId)
        {
            var result = await _customerService.GetByIdAsync(userId);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerService.GetAllAsync();
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CustomerAddDto customerAddDto)
        {
            var result = await _customerService.AddAsync(customerAddDto);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] Customer customer)
        {
            var result = _customerService.Update(customer);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int userId)
        {
            var result = _customerService.DeleteById(userId);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
    }
}

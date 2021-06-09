using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.Rental;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private IRentalService _rentalService;
        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(int rentalId)
        {
            var result = await _rentalService.GetByIdAsync(rentalId);
            return result.Success
             ? Ok(result)
             : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _rentalService.GetAllAsync();
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }

        [HttpGet("getrentallbycustomer")]
        public async Task<IActionResult> GetRentAllByCustomer(int carId, int customerId)
        {
            var result = await _rentalService.GetRentAllByCustomerAsync(carId, customerId);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(RentalAddDto rentalAddDto)
        {
          var result=await _rentalService.AddAsync(rentalAddDto);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(RentalUpdateDto rentalUpdateDto)
        {
            var result = await _rentalService.UpdateAsync(rentalUpdateDto);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int rentalId)
        {
            var result = await _rentalService.DeleteByIdAsync(rentalId);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
    }
}

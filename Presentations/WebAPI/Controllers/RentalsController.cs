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
        public IActionResult Get(int userId)
        {
            var data = _rentalService.GetById(userId);
            return Ok(data.Data);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }

        [HttpGet("getrentallbycustomer")]
        public IActionResult GetRentAllByCustomer(int carId, int customerId)
        {
            var result = _rentalService.GetRentAllByCustomer(carId, customerId);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(RentalAddDto rentalAddDto)
        {
            _rentalService.Add(rentalAddDto);
            return Ok();
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
        public IActionResult Delete(Rental rental)
        {
            _rentalService.Delete(rental);
            return Ok();
        }
    }
}

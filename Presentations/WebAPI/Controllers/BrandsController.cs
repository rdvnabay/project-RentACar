using Business.Abstract;
using Entities.Dtos.Brand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private IBrandService _brandService;
        public BrandsController(
            IBrandService brandService)
        {
            _brandService = brandService;
        }

        //Methods
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] BrandAddDto brandAddDto)
        {
            var result = await _brandService.AddAsync(brandAddDto);
            return result.Success 
                ? Ok(result) 
                : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int brandId)
        { 
            //TODO: GetById Asenkron
            var result = await _brandService.DeleteByIdAsync(brandId);
            return result.Success 
                ? Ok(result) 
                : BadRequest(result);
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(int brandId)
        {
            var result = await _brandService.GetByIdAsync(brandId);
            return result.Success 
                ? Ok(result) 
                : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _brandService.GetAllAsync();
            return result.Success
              ? Ok(result)
              : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] BrandUpdateDto brandUpdateDto)
        {
           var result = await _brandService.UpdateAsync(brandUpdateDto);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }
    }
}

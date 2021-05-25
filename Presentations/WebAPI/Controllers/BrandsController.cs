using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService _brandService;
        public BrandsController(
            IBrandService brandService)
        {
            _brandService = brandService;
        }

        //Methods
        [HttpPost("add")]
        public IActionResult Add(BrandAddDto brandAddDto)
        {
            var result = _brandService.Add(brandAddDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int brandId)
        {
            var brand = _brandService.GetById(brandId).Data;
            var result = _brandService.Delete(brand);
            return result.Success 
                ? Ok(result) 
                : BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int brandId)
        {
            var result = _brandService.GetById(brandId);
            return result.Success 
                ? Ok(result) 
                : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            return result.Success
              ? Ok(result)
              : BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(BrandDto brandDto)
        {
           var result = _brandService.Update(brandDto);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }
    }
}

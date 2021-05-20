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
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandService.Delete(brand);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();


        }

        [HttpGet("get")]
        public IActionResult Get(int brandId)
        {
            var result = _brandService.GetById(brandId);
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(BrandDto brandDto)
        {
           var result = _brandService.Update(brandDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

       
    }
}

using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService _brandService;
        private IMapper _mapper;
        public BrandsController(
            IBrandService brandService,
            IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }


        //Methods
        [HttpGet("get")]
        public IActionResult Get(int brandId)
        {
            var data = _brandService.GetById(brandId);
            return Ok(data.Data);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            //var result = _mapper.Map<List<BrandDto>>(data);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandService.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Brand brand)
        {
            _brandService.Update(brand);
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Brand brand)
        {
            //var result = _brandService.GetById(brandId);

            var result = _brandService.Delete(brand);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();


        }
    }
}

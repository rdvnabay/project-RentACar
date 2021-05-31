﻿using Business.Abstract;
using Entities.Dtos;
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
                ? Ok(result.Message) 
                : BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int brandId)
        { 
            //TODO: GetById Asenkron
            var brand = _brandService.GetById(brandId);
            var result = await _brandService.DeleteAsync(brand);
            return result.Success 
                ? Ok(result.Message) 
                : BadRequest(result.Message);
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
        public async Task<IActionResult> Update([FromBody] BrandDto brandDto)
        {
           var result = await _brandService.UpdateAsync(brandDto);
            return result.Success
               ? Ok(result.Message)
               : BadRequest(result.Message);
        }
    }
}

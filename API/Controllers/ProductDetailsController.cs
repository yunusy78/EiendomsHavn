using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindomsHavnAPI.DTOs.ProductDtos;
using EindomsHavnAPI.Repositories.ProductRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EindomsHavnAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailsRepository _productRepository;
        
        public ProductDetailsController(IProductDetailsRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
            
        }
        
        [HttpGet]
        [Route("GetAllProductsDetailsWithProduct")]
        public async Task<IActionResult> GetAllProductDetailsWithProductAsync()
        {
            var products = await _productRepository.GetAllProductDetailsWithProductAsync();
            return Ok(products);
            
        }
        
        
        [HttpGet]
        [Route("GetProductDetailsWithProductWithId")]
        public async Task<IActionResult> GetProductDetailsWithProductAsync(Guid id)
        {
            var products = await _productRepository.GetAllProductDetailsWithProductAsync(id);
            return Ok(products);
            
        }
        
        [HttpGet]
        [Route("GetProductDetailsWithId")]
        public async Task<IActionResult> GetProductDetailsAsync(Guid id)
        {
            var products = await _productRepository.GetByIdProductDetailsAsync(id);
            return Ok(products);
            
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductDetailsDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             _productRepository.CreateProductAsync(productDto);
            return Ok("Product created successfully");
        }
        
        
        
        
        
    }
}

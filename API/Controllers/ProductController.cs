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
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        [HttpGet]
        [Route("ProductsAdmin")]
     
        public async Task<IActionResult> GetAllProductsAdminAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
            
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
            
        }
        
        [HttpGet]
        [AllowAnonymous]
        [Route("GetAllProductsWithCategoryAndAddress")]
        public async Task<IActionResult> GetAllProductsWithCategoryAndAddressAsync()
        {
            var products = await _productRepository.GetAllProductsWithCategoryAsync();
            return Ok(products);
            
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(CreateProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            productDto.Status = true;
            productDto.CreatedAt = DateTime.Now;
            
             _productRepository.CreateProductAsync(productDto);
             
            return Ok("Product Created Successfully");
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(UpdateProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _productRepository.UpdateProductAsync(productDto);
            
            return Ok("Product Updated Successfully");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(Guid id)
        {
            _productRepository.DeleteProductAsync(id);
            return Ok("Product Deleted Successfully");
        }
        
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductByIdAsync(Guid id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return Ok(product);
        }
        
        
        
        
    }
}

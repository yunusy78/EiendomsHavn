using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindomsHavnAPI.Repositories.ProductRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EindomsHavnAPI.Controllers
{
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
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
            
        }
        
        [HttpGet]
        [Route("GetAllProductsWithCategoryAndAddress")]
        public async Task<IActionResult> GetAllProductsWithCategoryAndAddressAsync()
        {
            var products = await _productRepository.GetAllProductsWithCategoryAndAddressAsync();
            return Ok(products);
            
        }
        
        
        
    }
}

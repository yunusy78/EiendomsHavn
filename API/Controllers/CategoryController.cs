using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.ValidationRules;
using EindomsHavnAPI.DTOs.CategoryDtos;
using EindomsHavnAPI.Repositories.CategoryRepository;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EindomsHavnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoryRepository.GetAllCategoriesAsync();
            return Ok(result);
        }
        
        [HttpPost]
        
        public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
        {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = validator.Validate(categoryDto);
            
            
            if (!result.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            categoryDto.CreatedAt = DateTime.Now;
            _categoryRepository.CreateCategoryAsync(categoryDto);
            return Ok("Category Created Successfully");
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _categoryRepository.UpdateCategoryAsync(categoryDto);
            return Ok("Category Updated Successfully");
        }
        
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            _categoryRepository.DeleteCategoryAsync(id);
            return Ok("Category Deleted Successfully");
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var result = await _categoryRepository.GetCategoryByIdAsync(id);
            return Ok(result);
        }
        
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.EmployeeDtos;
using EindomsHavnAPI.DTOs.CategoryDtos;
using EindomsHavnAPI.Repositories.AboutRepository;
using EindomsHavnAPI.Repositories.CategoryRepository;
using EindomsHavnAPI.Repositories.EmployeeRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EindomsHavnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
       private readonly IEmployeeRepository _employeeRepository;


       public EmployeeController(IEmployeeRepository employeeRepository)
       {
           _employeeRepository = employeeRepository;
       }
       

       [HttpGet]
        public async Task<IActionResult> GetAllAbout()
        {
            var result = await _employeeRepository.GetAllEmployeeAsync();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(Guid id)
        {
            var result = await _employeeRepository.GetEmployeeByIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateEmployeeDto createAboutDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _employeeRepository.CreateAboutAsync(createAboutDto);
            return Ok("Employee Created Successfully");
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateEmployeeDto updateAboutDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _employeeRepository.UpdateAboutAsync(updateAboutDto);
            return Ok("Employee Updated Successfully");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(Guid id)
        {
            _employeeRepository.DeleteCategoryAsync(id);
            return Ok("Employee Deleted Successfully");
        }
        
        
        
    }
}

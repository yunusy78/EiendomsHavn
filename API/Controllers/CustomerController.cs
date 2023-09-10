using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.EmployeeDtos;
using EindomsHavnAPI.DTOs.CategoryDtos;
using EindomsHavnAPI.DTOs.Customer;
using EindomsHavnAPI.Repositories.AboutRepository;
using EindomsHavnAPI.Repositories.CategoryRepository;
using EindomsHavnAPI.Repositories.EmployeeRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EindomsHavnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
       private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
       

       [HttpGet]
        public async Task<IActionResult> GetAllAbout()
        {
            var result = await _customerRepository.GetAllEmployeeAsync();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(Guid id)
        {
            var result = await _customerRepository.GetEmployeeByIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateCustomerDto createAboutDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _customerRepository.CreateAboutAsync(createAboutDto);
            return Ok("Customer Created Successfully");
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(ResultCustomerDto updateAboutDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _customerRepository.UpdateAboutAsync(updateAboutDto);
            return Ok("Customer Updated Successfully");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(Guid id)
        {
            _customerRepository.DeleteCategoryAsync(id);
            return Ok("Customer Deleted Successfully");
        }
        
        
        
    }
}

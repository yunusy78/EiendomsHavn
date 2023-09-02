using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        
        
    }
}

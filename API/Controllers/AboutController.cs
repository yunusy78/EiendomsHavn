using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindomsHavnAPI.DTOs.CategoryDtos;
using EindomsHavnAPI.Repositories.AboutRepository;
using EindomsHavnAPI.Repositories.CategoryRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EindomsHavnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
       private readonly IAboutRepository _aboutRepository;


       public AboutController(IAboutRepository aboutRepository)
       {
           _aboutRepository = aboutRepository;
       }

       [HttpGet]
        public async Task<IActionResult> GetAllAbout()
        {
            var result = await _aboutRepository.GetAllAboutAsync();
            return Ok(result);
        }
        
        
        
    }
}

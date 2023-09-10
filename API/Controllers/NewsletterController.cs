using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindomsHavnAPI.DTOs.NewsletterDtos;
using EindomsHavnAPI.Repositories.NewsletterRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class NewsletterController : ControllerBase
    {
        private readonly INewsletterRepository _newsletterRepository;
        
        public NewsletterController(INewsletterRepository newsletterRepository)
        {
            _newsletterRepository = newsletterRepository;
        }
        
        [HttpGet]
       
        public async Task<IActionResult> GetAllNewslettersAsync()
        {
            var newsletters = await _newsletterRepository.GetAllNewslettersAsync();
            return Ok(newsletters);
            
        }
        
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateNewsletterAsync(CreateNewsletterDto newsletterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            newsletterDto.CreatedAt = DateTime.Now;
            _newsletterRepository.CreateNewsletterAsync(newsletterDto);
            return Ok("Newsletter Created Successfully");
        }
        
        
        [HttpPut]
        public async Task<IActionResult> UpdateNewsletterAsync(UpdateNewsletterDto newsletterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _newsletterRepository.UpdateNewsletterAsync(newsletterDto);
            return Ok("Newsletter Updated Successfully");
        }
        
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> DeleteNewsletterAsync(Guid id)
        {
            _newsletterRepository.DeleteNewsletterAsync(id);
            return Ok("Newsletter Deleted Successfully");
        }
        
        
        [HttpGet("{id}")]
        [AllowAnonymous]
        
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var result = await _newsletterRepository.GetNewsletterByIdAsync(id);
            return Ok(result);
        }
        
        
        
        
        
        
        
        
    }
}

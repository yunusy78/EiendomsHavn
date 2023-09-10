using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindomsHavnAPI.DTOs.ContactDtos;
using EindomsHavnAPI.Repositories.ContactRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        
        [HttpGet]
        
        public async Task<IActionResult> GetAlAsync()
        {
            var result = await _contactRepository.GetAllAsync();
            return Ok(result);
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync(CreateContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            contactDto.CreatedAt = DateTime.Now;
           _contactRepository.CreateAsync(contactDto);
            return Ok("Message Created Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _contactRepository.UpdateAsync(contactDto);
            return Ok("Message Updated Successfully");

        }
        
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            _contactRepository.DeleteAsync(id);
            return Ok("Message Deleted Successfully");
        }
        
        
        [HttpGet("{id}")]
        [AllowAnonymous]
        
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await  _contactRepository.GetByIdAsync(id);
            return Ok(result);
        }
        
        

    }
}

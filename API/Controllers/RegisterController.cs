using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindomsHavnAPI.DTOs.ApplicationUserDto;
using EindomsHavnAPI.Model;
using EindomsHavnAPI.Repositories.ApplicationUserRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IApplicationUserRepository _applicationUserRepository;

        public RegisterController(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(ApplicationUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Şifreyi hashle
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
        
                // Kullanıcı bilgilerini ApplicationUserDto'dan çıkar
                var user = new ApplicationUserDto()
                {
                    Email = model.Email,
                    PasswordHash = passwordHash
                };

                // Kullanıcı kaydı işlemi
                var userRegistered = await _applicationUserRepository.RegisterUser(user);

                if (userRegistered)
                {
                    return Ok("User registered successfully");
                }
                else
                {
                    return BadRequest("User registration failed");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    
    }
}
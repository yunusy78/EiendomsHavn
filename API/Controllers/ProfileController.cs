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
    public class ProfileController : ControllerBase
    {
        
        
        [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public IActionResult Profile()
        {
            return Ok("Profile");
        }

    
    }
}
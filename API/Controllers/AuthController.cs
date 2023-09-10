using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EindomsHavnAPI.DTOs.ApplicationUserDto;
using EindomsHavnAPI.Model;
using EindomsHavnAPI.Repositories.ApplicationUserRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IApplicationUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IApplicationUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(ApplicationUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcı kimlik doğrulama işlemi
                var user = await _userRepository.AuthenticateUser(model.Email!, model.Password);

                if (user != null)
                {
                    // Kullanıcı doğrulandı, kullanıcı rollerini alın
                    var roles = await _userRepository.GetRolesForUser(user);

                    // Kullanıcı doğrulandı, bir JWT token oluşturun
                    var token = CreateToken(user, roles);

                    // JWT token'i kullanıcıya dönün
                    return Ok(new { token });
                }
                else
                {
                    return BadRequest("Username or password is incorrect");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
        private string CreateToken(ApplicationUserDto userViewModel , string roles)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userViewModel.Email),
                new Claim(ClaimTypes.Role,roles)
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );
            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenHandler;
        }
        
        // AuthController.cs (veya uygun bir controller)
        [HttpPost]
        [Route("api/Auth/logout")]
        public IActionResult Logout()
        {
            // Kullanıcıyı oturumdan çıkarın (örneğin, JWT çerezini silin veya geçersizleştirin)

            // Örneğin, JWT çerezini silme
            Response.Cookies.Delete("JwtToken");

            return Ok("Logout successful");
        }
        
        

    }
}

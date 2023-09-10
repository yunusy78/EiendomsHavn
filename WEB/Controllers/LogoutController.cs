using Microsoft.AspNetCore.Mvc;
using web.DTOs.ApplicationUserDto;

namespace WEB.Controllers;

public class LogoutController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
       
        // Client tarafında Logout isteği gönderme (örnek)
        var httpClient = new HttpClient();

        var response = await httpClient.PostAsync("http://localhost:5076/api/Auth/api/Auth/logout", null);

        if (response.IsSuccessStatusCode)
        {
            // Logout işlemi başarılı oldu
           
           
            HttpContext.Response.Cookies.Delete("JwtToken");
            return RedirectToAction("Index", "Default");
        }
        else
        {
            // Logout işlemi başarısız oldu
            return RedirectToAction("Index", "Login");
        }
    
    }
}
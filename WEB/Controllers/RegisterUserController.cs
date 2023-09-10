using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using web.DTOs.ApplicationUserDto;

namespace WEB.Controllers;

public class RegisterUserController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    
    public RegisterUserController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    // GET
    public IActionResult Index()
    {
        
        return View();
    }
    
    
    [HttpPost]
    public async Task<IActionResult> RegisterUser(RegisterUserDto model)
    {
        var client = _clientFactory.CreateClient("api");
        var json = JsonConvert.SerializeObject(model);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5076/api/Register", data);
        var result = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Login");
        }
        else
        {
                ViewBag.ErrorMessage = result;
                return View("Index"); // Aynı sayfayı tekrar görüntüle
            
            
        }
    }
}
using System.Net;
using System.Net.Http.Headers;
using API.DTOs.EmployeeDtos;
using EindomsHavn.DTOs.CategoryDtos;
using EindomsHavnAPI.DTOs.NewsletterDtos;
using EindomsHavnAPI.DTOs.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace WEB.Areas.Admin.Controllers;
[Area("Admin")]

public class DashboardController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    
    public DashboardController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var jwtToken = HttpContext.Request.Cookies["JwtToken"];
        var client = _clientFactory.CreateClient("API");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var response = client.GetAsync("http://localhost:5076/api/Product/ProductsAdmin");
        var response2 = client.GetAsync("http://localhost:5076/api/Employee/EmployeeAdmin");
        var response3 = client.GetAsync("http://localhost:5076/api/Category/CategoriesAdmin");
        var response4 = client.GetAsync("http://localhost:5076/api/Newsletter");
        if (response2.Result.IsSuccessStatusCode)
        {
            var result = response.Result.Content.ReadAsStringAsync();
            var contacts = JsonConvert.DeserializeObject<List<ResultProductDto>>(result.Result);
            ViewBag.ProductCount = contacts.Count;
            var result2 = response2.Result.Content.ReadAsStringAsync();
            var contacts2 = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(result2.Result);
            ViewBag.EmployeeCount = contacts2.Count;
            
            var result3 = response3.Result.Content.ReadAsStringAsync();
            var contacts3 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(result3.Result);
            ViewBag.CategoryCount = contacts3.Count;
            
            var result4 = response4.Result.Content.ReadAsStringAsync();
            var contacts4 = JsonConvert.DeserializeObject<List<ResultNewsletterDto>>(result4.Result);
            ViewBag.NewsletterCount = contacts4.Count;

            
            return View(contacts);
        }
        
        if (response.Result.StatusCode == HttpStatusCode.Unauthorized)
        {
            return RedirectToAction("Unauthorized", "ErrorPage", new {code = 401, area = ""});
        }
        
        if (response.Result.StatusCode == HttpStatusCode.Forbidden)
        {
            return RedirectToAction("Unauthorized", "ErrorPage", new {code = 403, area = ""});
        }

        return RedirectToAction("Index", "Default" , new {area = ""});
    }
}
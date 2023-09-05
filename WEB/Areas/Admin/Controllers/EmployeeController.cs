using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEB.DTOs.AboutDtos;
using X.PagedList;

namespace WEB.Areas.Admin.Controllers;
[Area("Admin")]
public class EmployeeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public EmployeeController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    // GET
    public IActionResult Index(int page=1)
    {
        var client = _httpClientFactory.CreateClient();
        var response = client.GetAsync("http://localhost:5076/api/Employee").Result;
        if (response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadAsStringAsync().Result;
            var employees = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(result).ToPagedList(page,5);;;
            return View(employees);
        }
        return View();
    }
}
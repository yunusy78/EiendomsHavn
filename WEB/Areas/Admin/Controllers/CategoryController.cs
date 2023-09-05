using EindomsHavn.DTOs.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace WEB.Areas.Admin.Controllers;
[Area("Admin")]
public class CategoryController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public CategoryController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    // GET
    public async Task<IActionResult> Index( int page=1)
    {
        var client = _httpClientFactory.CreateClient();
        var response = client.GetAsync("http://localhost:5076/api/Category").Result;
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(result).ToPagedList(page,5);;
            return View(products);
        }
        return View();
    }
}
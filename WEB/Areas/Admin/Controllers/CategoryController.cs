using System.Net.Http.Headers;
using System.Text;
using EiendomsHavn.DTOs.CategoryDtos;
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
        var jwtToken = HttpContext.Request.Cookies["JwtToken"];
        var client =  _httpClientFactory.CreateClient("API");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var response = client.GetAsync("http://localhost:5076/api/Category/CategoriesAdmin").Result;
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(result).ToPagedList(page,5);;
            return View(products);
        }
        return View();
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto dto)
    {
        dto.Status = true;
        dto.CreatedAt = DateTime.Now;
        var jwtToken = HttpContext.Request.Cookies["JwtToken"];
        var client =  _httpClientFactory.CreateClient("API");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var json = JsonConvert.SerializeObject(dto);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5076/api/Category", data);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(dto);
    }
    
    public async Task<IActionResult> Delete(Guid id)
    {
        var jwtToken = HttpContext.Request.Cookies["JwtToken"];
        var client =  _httpClientFactory.CreateClient("API");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var response = await client.DeleteAsync($"http://localhost:5076/api/Category/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
        
    }
    
    
    
    public async Task<IActionResult> Update(Guid id)
    {
        var jwtToken = HttpContext.Request.Cookies["JwtToken"];
        var client =  _httpClientFactory.CreateClient("API");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var response = await client.GetAsync($"http://localhost:5076/api/Category/{id}");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var category = JsonConvert.DeserializeObject<GetByIdCategoryDto>(result);
            return View(category);
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(UpdateCategoryDto dto)
    {
        var jwtToken = HttpContext.Request.Cookies["JwtToken"];
        var client =  _httpClientFactory.CreateClient("API");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var json = JsonConvert.SerializeObject(dto);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5076/api/Category", data);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    
    
}
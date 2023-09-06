using System.Text;
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
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(ResultEmployeeDto dto, IFormFile? file)
    {
        if (file != null)
        {
            var extension = Path.GetExtension(file.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageFile/Employee/" + newImageName);
            var stream = new FileStream(location, FileMode.Create);
            file.CopyToAsync(stream);
            dto.EmployeeImageUrl =@"/ImageFile/Employee/"+ newImageName;
        }
        else
        {
            dto.EmployeeImageUrl = "default.png ";
        }
        dto.EmployeeStatus = true;
        var client = _httpClientFactory.CreateClient();
        var json = JsonConvert.SerializeObject(dto);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5076/api/Employee", data);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(dto);
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync("http://localhost:5076/api/Employee/" + id);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Update(Guid id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5076/api/Employee/{id}");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var employee = JsonConvert.DeserializeObject<ResultEmployeeDto>(result);
            return View(employee);
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(ResultEmployeeDto dto, IFormFile? file)
    {
        if (file != null)
        {
            var extension = Path.GetExtension(file.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageFile/Employee/" + newImageName);
            var stream = new FileStream(location, FileMode.Create);
            file.CopyToAsync(stream);
            dto.EmployeeImageUrl =@"/ImageFile/Employee/"+ newImageName;
        }
        else
        {
            dto.EmployeeImageUrl = dto.EmployeeImageUrl;
        }
        var client = _httpClientFactory.CreateClient();
        var json = JsonConvert.SerializeObject(dto);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5076/api/Employee", data);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    
   
}
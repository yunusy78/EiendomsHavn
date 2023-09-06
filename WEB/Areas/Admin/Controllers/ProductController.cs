using System.Text;
using EiendomsHavn.DTOs.ProductDtos;
using EindomsHavn.DTOs.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WEB.DTOs.AboutDtos;
using Web.DTOs.ProductDtos;
using WEB.DTOs.ProductDtos;
using X.PagedList;

namespace WEB.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductController : Controller
{
    IHttpClientFactory _clientFactory;
    
    public ProductController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    public async Task<IActionResult> Index( int page=1)
    {
        var client = _clientFactory.CreateClient("API");
        var response = client.GetAsync("http://localhost:5076/api/Product").Result;
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(result).ToPagedList(page,2);;
            return View(products);
        }
        else
        {
            return RedirectToAction("Index", "Default", new {area = ""});
        }
    }
    
    // GET
    public async Task<IActionResult> Create()
    {
        var client = _clientFactory.CreateClient("API");
        var response = client.GetAsync("http://localhost:5076/api/Category").Result;
        if (response.IsSuccessStatusCode)
        {
            var categories = await response.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            List<SelectListItem> valueStatus = (from x in categories
                select new SelectListItem
                {
                    Text = x.Name,
                    Value = x.CategoryId.ToString()
                }).ToList();
            ViewBag.Categories = valueStatus;
        }
        
        var client2 = _clientFactory.CreateClient("API");
        var response2 = client2.GetAsync("http://localhost:5076/api/Employee").Result;
        
        if (response2.IsSuccessStatusCode)
        {
            var employees = await response2.Content.ReadFromJsonAsync<List<ResultEmployeeDto>>();
            List<SelectListItem> valueStatus2 = (from x in employees
                select new SelectListItem
                {
                    Text = x.EmployeeName,
                    Value = x.EmployeeId.ToString()
                }).ToList();
            ViewBag.Employees = valueStatus2;
        }

        return View();
    }
    
    [HttpPost]
    public IActionResult Create(CreateProductDto productDto, IFormFile? file1, IFormFile? file2)
    {
        
        
        if (file1 != null)
        {
            var extension = Path.GetExtension(file1.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageFile/Product/" + newImageName);
            var stream = new FileStream(location, FileMode.Create);
            file1.CopyToAsync(stream);
            productDto.ImageUrl =@"/ImageFile/Product/"+ newImageName;
        }
      else
        {
            productDto.ImageUrl = "default.png ";
        }
        
       if (file2 != null)
        {
            var extension = Path.GetExtension(file2.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageFile/Product/" + newImageName);
            var stream = new FileStream(location, FileMode.Create);
            file2.CopyToAsync(stream);
            productDto.CoverImageUrl =@"/ImageFile/Product/"+ newImageName;
        }
        else
        {
            productDto.CoverImageUrl = "default.png ";
        }
        productDto.CreatedAt = DateTime.Now;
        productDto.Status = true;
       var client = _clientFactory.CreateClient("API");
       var response = client.PostAsJsonAsync("http://localhost:5076/api/Product", productDto).Result;
        
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "ProductDetails");
        }
        else
        {
            return RedirectToAction("Index", "Default", new {area = ""});
        }
        
    }
    
    
    public async Task<IActionResult> Update(Guid id)
    {
        var client3 = _clientFactory.CreateClient("API");
        var response3 = client3.GetAsync("http://localhost:5076/api/Category").Result;
        if (response3.IsSuccessStatusCode)
        {
            var categories = await response3.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            List<SelectListItem> valueStatus = (from x in categories
                select new SelectListItem
                {
                    Text = x.Name,
                    Value = x.CategoryId.ToString()
                }).ToList();
            ViewBag.Categories2 = valueStatus;
        }
        
        var client2 = _clientFactory.CreateClient("API");
        var response2 = client2.GetAsync("http://localhost:5076/api/Employee").Result;
        
        if (response2.IsSuccessStatusCode)
        {
            var employees = await response2.Content.ReadFromJsonAsync<List<ResultEmployeeDto>>();
            IEnumerable<SelectListItem>valueStatus2 = (from x in employees
                select new SelectListItem
                {
                    Text = x.EmployeeName,
                    Value = x.EmployeeId.ToString()
                }).ToList();
            ViewBag.Employees2 = valueStatus2;
        }

        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5076/api/Product/{id}");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<CreateProductDto>(result);
            return View(product);
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(CreateProductDto dto, IFormFile? file1, IFormFile? file2)
    {
        if (file1 != null)
        {
            var extension = Path.GetExtension(file1.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageFile/Product/" + newImageName);
            var stream = new FileStream(location, FileMode.Create);
            file1.CopyToAsync(stream);
            dto.ImageUrl =@"/ImageFile/Product/"+ newImageName;
        }
        else
        {
            dto.ImageUrl = dto.ImageUrl;
        }
        
        if (file2 != null)
        {
            var extension = Path.GetExtension(file2.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageFile/Product/" + newImageName);
            var stream = new FileStream(location, FileMode.Create);
            file2.CopyToAsync(stream);
            dto.CoverImageUrl =@"/ImageFile/Product/"+ newImageName;
        }
        else
        {
            dto.CoverImageUrl = dto.CoverImageUrl;
        }
        
        
        var client = _clientFactory.CreateClient();
        var json = JsonConvert.SerializeObject(dto);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5076/api/Product", data);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    
    
}
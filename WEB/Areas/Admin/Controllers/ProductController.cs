using EiendomsHavn.DTOs.ProductDtos;
using EindomsHavn.DTOs.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB.DTOs.AboutDtos;

namespace WEB.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductController : Controller
{
    IHttpClientFactory _clientFactory;
    
    public ProductController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    // GET
    public async Task<IActionResult> Index()
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
}
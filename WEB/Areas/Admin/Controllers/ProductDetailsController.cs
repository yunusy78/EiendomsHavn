using EiendomsHavn.DTOs.ProductDtos;
using EindomsHavn.DTOs.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEB.DTOs.ProductDetailsDtos;
using X.PagedList;

namespace WEB.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductDetailsController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    
    public ProductDetailsController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    // GET
    public async Task<IActionResult> Index(int page=1)
    {
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5076/api/ProductDetails/GetAllProductsDetailsWithProduct");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductDetailsDto>>(result).ToPagedList(page,5);;
            return View(products);
        }
        return View();
    }
    
    
    public async Task<IActionResult> Update(Guid id)
    {
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5076/api/ProductDetails/GetProductDetailsWithId?id=" + id);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<GetByIdProductDetailsDto>>(result);
            
            var product = products.FirstOrDefault();

            if (product != null)
            {
                return View(product);
            }
            else
            {
                return NotFound(); 
            }
        }
        return View();
    }



[HttpPost]
public IActionResult Update(CreateProductDetailsDto productDto)
{
    var client = _clientFactory.CreateClient("API");
    var response = client.PostAsJsonAsync("http://localhost:5076/api/ProductDetails", productDto).Result;
        
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
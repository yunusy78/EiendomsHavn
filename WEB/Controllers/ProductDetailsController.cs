using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEB.DTOs.ProductDetailsDtos;
using WEB.DTOs.ProductDtos;
using X.PagedList;

namespace WEB.Controllers;

public class ProductDetailsController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    
    public ProductDetailsController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    
    // GET
    public async Task<IActionResult> Index(string? search, string type, string?search2, int page=1)
    {
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5076/api/ProductDetails/GetAllProductsDetailsWithProduct");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductDetailsDto>>(result);
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrEmpty(type))
            {
                products = products.Where(x => x.City.ToLower().Contains(search.ToLower()) && x.Name.ToLower().Contains(type.ToLower())).ToList();
                return View(products.ToPagedList(page, 3));
            }
            
            else if (!string.IsNullOrEmpty(type))
      
            {
                products = products.Where(x => x.Name.ToLower().Contains(type.ToLower())).ToList();
                return View(products.ToPagedList(page, 3));
            }
            
            else if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(x => x.City.ToLower().Contains(search.ToLower())).ToList();
                return View(products.ToPagedList(page, 3));
            }
            
            else if (!string.IsNullOrEmpty(search2))
            {
                products = products.Where(x => x.City.ToLower().Contains(search2.ToLower())|| x.Name.ToLower().Contains(search2.ToLower())).ToList();
                return View(products.ToPagedList(page, 3));
            }

            return View(products.ToPagedList(page,3));
        }
        return View();
    }
    
    public async Task<IActionResult> Details(Guid id)
    {
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5076/api/ProductDetails/GetProductDetailsWithProductWithId?id=" + id);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var productList = JsonConvert.DeserializeObject<List<ResultProductDetailsDto>>(result);
            return View(productList);
        }
        return View();
    }

}
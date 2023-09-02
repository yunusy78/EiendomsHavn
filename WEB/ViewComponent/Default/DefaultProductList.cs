using EiendomsHavn.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEB.DTOs.ProductDtos;

namespace WEB.ViewComponent.Default;

public class DefaultProductList : Microsoft.AspNetCore.Mvc.ViewComponent
{
    
    private readonly IHttpClientFactory _clientFactory;
    
    public DefaultProductList(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5076/api/Product/GetAllProductsWithCategoryAndAddress");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(result);
            return View(products);
        }
        
        return View();
    }
    
}
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEB.DTOs.ProductDtos;

namespace WEB.ViewComponent.AboutComponent;

public class Statistic1 : Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly IHttpClientFactory _clientFactory;
    
    public Statistic1(IHttpClientFactory clientFactory)
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
            ViewBag.Leie = products!.Count(x => x.Type == "Til Leie"); 
            ViewBag.Salg = products!.Count(x => x.Type == "Til Salgs");
            return View();

        }
        return View();
    }
    
}
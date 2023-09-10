using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEB.DTOs.Customer;

namespace WEB.ViewComponent.Default;

public class DefaultOurClientsComponent : Microsoft.AspNetCore.Mvc.ViewComponent
{
    
    private readonly IHttpClientFactory _httpClientFactory;
    
    public DefaultOurClientsComponent(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5076/api/Customer");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<List<ResultCustomerDto>>(result);
            return View(customers);
        }
        return View();
            
    }
    
}
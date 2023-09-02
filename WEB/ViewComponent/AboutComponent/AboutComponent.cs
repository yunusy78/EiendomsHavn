using Microsoft.AspNetCore.Mvc;
using WEB.DTOs.AboutDtos;

namespace WEB.ViewComponent.AboutComponent;

public class AboutComponent : Microsoft.AspNetCore.Mvc.ViewComponent
{
    IHttpClientFactory _clientFactory;
    
    public AboutComponent(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _clientFactory.CreateClient("API");
        var response = client.GetAsync("http://localhost:5076/api/About").Result;
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<List<ResultAboutDto>>();
            return View(result);
        }
        else
        {
            return View();
        }
    }
    
}
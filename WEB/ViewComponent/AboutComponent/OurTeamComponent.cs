using Microsoft.AspNetCore.Mvc;
using WEB.DTOs.AboutDtos;

namespace WEB.ViewComponent.AboutComponent;

public class OurTeamComponent : Microsoft.AspNetCore.Mvc.ViewComponent
{
    IHttpClientFactory _clientFactory;
    
    public OurTeamComponent(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _clientFactory.CreateClient("API");
        var response = client.GetAsync("http://localhost:5076/api/Employee").Result;
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<List<ResultEmployeeDto>>();
            return View(result);
        }
        else
        {
            return View();
        }
    }
    
    
}
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEB.DTOs.CitiyDtos;

namespace WEB.ViewComponent.Default;

public class DefaultPopularLocationsComponent : Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly IHttpClientFactory _clientFactory;


    public DefaultPopularLocationsComponent(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5076/api/City");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ResultCityDto>>(result);
                return View(products);
            }
            return View();
            
        }
}
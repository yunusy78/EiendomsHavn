using EindomsHavn.DTOs.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using web.DTOs.ApplicationUserDto;
using WEB.DTOs.CitiyDtos;

namespace WEB.Controllers;

public class DefaultController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    
    public DefaultController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5076/api/City");
        var response2 = await client.GetAsync("http://localhost:5076/api/Category");
        if (response.IsSuccessStatusCode && response2.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var result2 = await response2.Content.ReadAsStringAsync();
            var city = JsonConvert.DeserializeObject<List<ResultCityDto>>(result);
            var category = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(result2);
            List<SelectListItem> valueStatus = (from x in city
                select new SelectListItem
                {
                    Text = x.City,
                    Value = x.Id.ToString()
                }).ToList();
            List<SelectListItem> valueStatus2 = (from x in category
                select new SelectListItem
                {
                    Text = x.Name,
                    Value = x.CategoryId.ToString()
                }).ToList();
            ViewBag.Cities = valueStatus;
            ViewBag.Categories = valueStatus2;
            
            return View();
            
        }
        
        return View();
    }
    
    public async Task<bool> IsAuthenticatedAsync()
    {
        try
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5076/api/Auth/api/IsAuthenticated");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return bool.Parse(content); // API'den dönen yanıtı bool'a çevirin
            }
            else
            {
                // API'den geçersiz yanıt alındıysa, kullanıcı oturumu kapalıdır.
                return false;
            }
        }
        catch (Exception)
        {
            // API'ye ulaşılamadıysa, kullanıcı oturumu kapalıdır.
            return false;
        }
    }
    
}
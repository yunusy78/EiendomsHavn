using Microsoft.AspNetCore.Mvc;
using WEB.DTOs.NewslettersDtos;

namespace WEB.Controllers;

public class NewsletterController : Controller
{
    IHttpClientFactory _clientFactory;
    
    public NewsletterController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    [HttpPost]
    public IActionResult Create(CreateNewsletterDto newsletterDto)
    {
        var client = _clientFactory.CreateClient("API");
        var response = client.PostAsJsonAsync("http://localhost:5076/api/Newsletter", newsletterDto).Result;
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Default");
        }
          else
            {
                return RedirectToAction("Index", "Default");
            }
        
    }
}
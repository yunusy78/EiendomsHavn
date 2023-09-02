using Microsoft.AspNetCore.Mvc;
using WEB.DTOs.ContactDtos;

namespace WEB.Controllers;

public class ContactController : Controller
{
    IHttpClientFactory _clientFactory;
    
    public ContactController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Create(CreateContactDto contactDto)
    {
        contactDto.CreatedAt = DateTime.Now;
        contactDto.Status = true;
        var client = _clientFactory.CreateClient("API");
        var response = client.PostAsJsonAsync("http://localhost:5076/api/Contact", contactDto ).Result;
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Contact");
        }
        else
        {
            return RedirectToAction("Index", "Default");
        }
        
    }
}
using System.Net.Http.Headers;
using System.Text;
using EindomsHavnAPI.DTOs.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace WEB.Areas.Admin.Controllers;
[Area("Admin")]
public class ContactController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public ContactController(IHttpClientFactory clientFactory)
    {
        _httpClientFactory = clientFactory;
    }
    
    // GET
    public IActionResult Index(int page=1)
    {
        var jwtToken = HttpContext.Request.Cookies["JwtToken"];
        var client =  _httpClientFactory.CreateClient("API");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var response = client.GetAsync("http://localhost:5076/api/Contact");
        if (response.Result.IsSuccessStatusCode)
        {
            var result = response.Result.Content.ReadAsStringAsync();
            var contacts = JsonConvert.DeserializeObject<List<ResultContactDto>>(result.Result).ToPagedList(page, 5);
            return View(contacts);
        }
        return View();
    }
    
    
    public IActionResult Update(Guid id)
    {
        var jwtToken = HttpContext.Request.Cookies["JwtToken"];
        var client =  _httpClientFactory.CreateClient("API");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var response = client.GetAsync("http://localhost:5076/api/Contact/" + id);
        if (response.Result.IsSuccessStatusCode)
        {
            var result = response.Result.Content.ReadAsStringAsync();
            var contact = JsonConvert.DeserializeObject<UpdateContactDto>(result.Result);
            return View(contact);
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(UpdateContactDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        var jwtToken = HttpContext.Request.Cookies["JwtToken"];
        var client =  _httpClientFactory.CreateClient("API");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var json = JsonConvert.SerializeObject(dto);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("http://localhost:5076/api/Contact", data);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View(dto);
    }
    
    public async Task<IActionResult> Delete(Guid id)
    {
        var jwtToken = HttpContext.Request.Cookies["JwtToken"];
        var client =  _httpClientFactory.CreateClient("API");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var response = await client.DeleteAsync("http://localhost:5076/api/Contact/" + id);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }
}
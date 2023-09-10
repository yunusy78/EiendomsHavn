using System.Net.Http.Headers;
using System.Text;
using EindomsHavnAPI.DTOs.NewsletterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace WEB.Areas.Admin.Controllers;
[Area("Admin")]
public class NewsletterController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public NewsletterController(IHttpClientFactory clientFactory)
    {
        _httpClientFactory = clientFactory;
    }
    
    // GET
    public IActionResult Index(int page=1)
    {
        var jwtToken = HttpContext.Request.Cookies["JwtToken"];
        var client =  _httpClientFactory.CreateClient("API");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var response = client.GetAsync("http://localhost:5076/api/Newsletter");
        if (response.Result.IsSuccessStatusCode)
        {
            var result = response.Result.Content.ReadAsStringAsync();
            var newsletters = JsonConvert.DeserializeObject<List<ResultNewsletterDto>>(result.Result).ToPagedList(page , 5);
            return View(newsletters);
        }
        return View();
    }
    
    
    public IActionResult Update(Guid id)
    {
        var jwtToken = HttpContext.Request.Cookies["JwtToken"];
        var client =  _httpClientFactory.CreateClient("API");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var response = client.GetAsync("http://localhost:5076/api/Newsletter/" + id);
        if (response.Result.IsSuccessStatusCode)
        {
            var result = response.Result.Content.ReadAsStringAsync();
            var newsletter = JsonConvert.DeserializeObject<UpdateNewsletterDto>(result.Result);
            return View(newsletter);
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(UpdateNewsletterDto dto)
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
        var response = await client.PutAsync("http://localhost:5076/api/Newsletter", data);
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
        var response = await client.DeleteAsync("http://localhost:5076/api/Newsletter/" + id);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }
    
}
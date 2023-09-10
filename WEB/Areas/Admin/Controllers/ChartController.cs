using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEB.DTOs.ProductDtos;

namespace WEB.Areas.Admin.Controllers;
[Area("Admin")]
public class ChartController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ChartController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var jwtToken = HttpContext.Request.Cookies["JwtToken"];
        var client =  _httpClientFactory.CreateClient("API");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var response = client.GetAsync("http://localhost:5076/api/Product/GetAllProductsWithCategoryAndAddress").Result;
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(result);
            
            var productCounts = products
                .GroupBy(r => r.CategoryId)
                .Select(group => new
                {
                    Name = group.First().Name,
                    Count = group.Count()
                })
                .ToList();
            return View(productCounts);
        }
        return View();

    }
    public IActionResult Index2()
    {
        return View();
    }

    
        public async Task<IActionResult> CityChart()
        {
            try
            {
                var jwtToken = HttpContext.Request.Cookies["JwtToken"];
                var client =  _httpClientFactory.CreateClient("API");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                var response = await client.GetAsync("http://localhost:5076/api/Product");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(result);

                    var cityCounts = products
                        .GroupBy(x => x.City)
                        .Select(group => new
                        {
                            Name = group.Key,
                            Count = group.Count()
                        })
                        .ToList();

                    return Json(new { jsonlist = cityCounts });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return RedirectToAction("Index", "Chart", new { area = "Admin" });
        }
        
        
        public async Task<IActionResult> CategoryChart()
        {
            try
            {
                var jwtToken = HttpContext.Request.Cookies["JwtToken"];
                var client =  _httpClientFactory.CreateClient("API");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                var response = await client.GetAsync("http://localhost:5076/api/Product");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(result);

                    var cityCounts = products
                        .GroupBy(x => x.Name)
                        .Select(group => new
                        {
                            Name = group.Key,
                            Count = group.Count()
                        })
                        .ToList();

                    return Json(new { jsonlist = cityCounts });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return RedirectToAction("Index", "Chart", new { area = "Admin" });
        }
    
        public async Task<IActionResult> EmployeeChart()
        {
            try
            {
                var jwtToken = HttpContext.Request.Cookies["JwtToken"];
                var client =  _httpClientFactory.CreateClient("API");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                var response = await client.GetAsync("http://localhost:5076/api/Product");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(result);

                    var cityCounts = products
                        .GroupBy(x => x.EmployeeName)
                        .Select(group => new
                        {
                            Name = group.Key,
                            Count = group.Count()
                        })
                        .ToList();

                    return Json(new { jsonlist = cityCounts });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return RedirectToAction("Index", "Chart", new { area = "Admin" });
        }
}
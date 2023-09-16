using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using web.DTOs.ApplicationUserDto;

namespace YourWebAppNamespace.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        
        public LoginController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        
        // GET: /Login
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(UserDto model)
        {
            
            // Kullanıcı kimlik doğrulama işlemi
            var token = await GetJwtTokenAsync(model.Email, model.Password);

            if (token != null)
            {
                // JWT ile güvenli kaynağa erişim sağlanır
                var resourceResponse = await AccessSecureResourceAsync(token);

                if (resourceResponse != null)
                {
                    // Kaynak erişimi başarılı oldu, isterseniz bu yanıtı kullanabilirsiniz
                }
                else
                {
                    // Kaynak erişimi başarısız oldu, uygun bir işlem yapabilirsiniz
                }
                
                
                return RedirectToAction("Index", "Default", new {area=""});
            }
            else
            {
                ViewBag.ErrorMessage = "Username or password is incorrect";
                return RedirectToAction("Index");
            }
        }


        private async Task<string> GetJwtTokenAsync(string email, string password)
        {
            var authRequest = new
            {
                Email = email,
                Password = password
            };

            var apiBaseUrl = "http://localhost:5076"; // API'nizin başlangıç URL'sini burada tanımlayın

            var content = new StringContent(JsonConvert.SerializeObject(authRequest), Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync($"{apiBaseUrl}/api/Auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var tokenResponse = await response.Content.ReadAsStringAsync();
                    var token = JsonConvert.DeserializeAnonymousType(tokenResponse, new { token = "" });
                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true, // JavaScript tarafından erişilemez
                        Expires = DateTime.UtcNow.AddHours(1) // Tokenin süresini ayarlayın
                    };


                    HttpContext.Response.Cookies.Append("JwtToken", token!.token, cookieOptions);
                    
                    return token.token;
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpPost]
        private async Task<string> AccessSecureResourceAsync(string token)
        {
            var client = _clientFactory.CreateClient("API");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync("http://localhost:5076/api/Product");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }

            return null;
        }
        
        [HttpGet]
        public IActionResult IsAuthenticated()
        {
            string jwtToken = Request.Cookies["JwtToken"];

            bool isAuthenticated = !string.IsNullOrEmpty(jwtToken);
            
            return Ok(isAuthenticated);
        }
        
        [HttpGet]
        public IActionResult IsAdmin()
        {
            var jwtToken = HttpContext.Request.Cookies["JwtToken"];
            var client =  _clientFactory.CreateClient("API");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            var response = client.GetAsync("http://localhost:5076/api/Category/CategoriesAdmin").Result;
            if (response.IsSuccessStatusCode)
            {
                bool isAdmin = true;
                return Ok(isAdmin);
            }
            else
            {
                bool isAdmin = false;
                return Ok(isAdmin);
            }
           
        }
        

    }
}

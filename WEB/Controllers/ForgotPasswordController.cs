using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using web.DTOs.ApplicationUserDto;

namespace WEB.Controllers;

public class ForgotPasswordController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    
    public ForgotPasswordController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordDto dto)
    {
        try
        {
            dto.ResetToken = "123";
            dto.ResetTokenExpiry = DateTime.Now.AddHours(1);
            dto.PasswordHash = "123";
            dto.Id = "123";
            var client = _clientFactory.CreateClient("api");
            var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Post, "http://localhost:5076/api/ForgetPassword")
            {
                Content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json")
            });

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                

                if (result != null)
                {
                    return RedirectToAction("Index2", "ForgotPassword", new { area = "", resetToken = result });
                }
            }

            ViewBag.ErrorMessage = "Email not found or an error occurred during password reset.";
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            // Hata yakalama, istisna ile başarısızlık durumlarına daha iyi hata işleme sağlar
            ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
            return RedirectToAction("Index");
        }
    }

    
    public IActionResult Index2(string resetToken)
    {
        ViewBag.ResetToken = resetToken;
        return View();
    }
    
    
    [HttpPost]
    public async Task<IActionResult> ResetPassword(string resetToken, string newPassword)
    {
        var client = _clientFactory.CreateClient("api");

        var resetPasswordUrl = $"http://localhost:5076/api/ForgetPassword/reset-password?resetToken={resetToken}&newPassword={newPassword}";

        var response = await client.PostAsync(resetPasswordUrl, null);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Login", new {area=""});
        }
        else
        {
            ViewBag.ErrorMessage = "Password reset failed";
            return RedirectToAction("Index");
        }
    
        // Dönüş işlemleri
    }

    
    
    
}
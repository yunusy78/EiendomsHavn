using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers;

public class ErrorPageController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
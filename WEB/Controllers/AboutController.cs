using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers;

public class AboutController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
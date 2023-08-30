using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers;

public class DefaultController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
}
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers;

public class ErrorPageController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Unauthorized(int code)
    {
        ViewBag.Code = code;
        string errorMessage = "";

        switch (code)
        {
            case 401:
                errorMessage = "Du har ikke tilgang til denne ressursen (Uautorisert).";
                break;
            case 403:
                errorMessage = "Du har ikke tilstrekkelige rettigheter til å få tilgang til denne ressursen (Forbudt).";
                break;
            default:
                errorMessage = "Det oppstod en feil.";
                break;
        }

        ViewBag.ErrorMessage = errorMessage;
        return View();
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WEB.ViewComponent.Default;

public class DefaultIndexComponent : Microsoft.AspNetCore.Mvc.ViewComponent
{
    
    public IViewComponentResult Invoke()
    {
        return View();
    }
   
}
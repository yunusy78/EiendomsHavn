﻿using Microsoft.AspNetCore.Mvc;

namespace WEB.ViewComponent.Default;

public class DefaultProductList : Microsoft.AspNetCore.Mvc.ViewComponent
{
    
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}
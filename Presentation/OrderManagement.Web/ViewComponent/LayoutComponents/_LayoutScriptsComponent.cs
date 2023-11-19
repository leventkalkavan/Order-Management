using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.Web.ViewComponent.LayoutComponents;

public class _LayoutScriptsComponent: Microsoft.AspNetCore.Mvc.ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
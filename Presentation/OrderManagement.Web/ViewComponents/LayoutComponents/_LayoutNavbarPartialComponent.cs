using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.Web.ViewComponent.LayoutComponents;

public class _LayoutNavbarPartialComponent: Microsoft.AspNetCore.Mvc.ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.Web.ViewComponent.UILayoutComponents;

public class _UILayoutNavbarPartialComponent: Microsoft.AspNetCore.Mvc.ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
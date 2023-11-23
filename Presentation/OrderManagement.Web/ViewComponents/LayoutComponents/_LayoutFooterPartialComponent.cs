using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.Web.ViewComponents.LayoutComponents;

public class _LayoutFooterPartialComponent: Microsoft.AspNetCore.Mvc.ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
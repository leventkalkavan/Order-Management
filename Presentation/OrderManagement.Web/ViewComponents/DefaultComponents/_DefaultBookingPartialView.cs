using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.Web.ViewComponents.DefaultComponents;

public class _DefaultBookingPartialView: Microsoft.AspNetCore.Mvc.ViewComponent
{
public IViewComponentResult Invoke()
{
    return View();
}
}
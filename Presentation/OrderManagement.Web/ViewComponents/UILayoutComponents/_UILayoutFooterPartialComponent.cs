using Microsoft.AspNetCore.Mvc.ViewComponents;
using Newtonsoft.Json;
using OrderManagement.Web.DTOs.ContactWebDto;
using OrderManagement.Web.DTOs.ReferenceWebDto;

namespace OrderManagement.Web.ViewComponents.UILayoutComponents;

public class _UILayoutFooterPartialComponent: Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _UILayoutFooterPartialComponent(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ViewViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5026/api/Contacts");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactWebDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
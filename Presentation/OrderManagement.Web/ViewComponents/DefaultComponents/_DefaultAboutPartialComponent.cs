using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Newtonsoft.Json;
using OrderManagement.Web.DTOs.AboutWebDto;
using OrderManagement.Web.DTOs.ProductWebDto;

namespace OrderManagement.Web.ViewComponents.DefaultComponents;

public class _DefaultAboutPartialComponent: Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultAboutPartialComponent(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ViewViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5026/api/Abouts");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutWebDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
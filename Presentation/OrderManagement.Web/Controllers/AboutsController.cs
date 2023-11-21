using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderManagement.Web.DTOs.AboutWebDto;
using OrderManagement.Web.DTOs.AboutWebDto;

namespace OrderManagement.Web.Controllers
{
    public class AboutsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
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

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutWebDto createAboutWebDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAboutWebDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5026/api/Abouts", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        
        public async Task<IActionResult> DeleteAbout(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:5026/api/Abouts/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
        
            return NotFound();
        }
        
        public async Task<IActionResult> UpdateAbout(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5026/api/Abouts/{id}");
        
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var about = JsonConvert.DeserializeObject<UpdateAboutWebDto>(jsonData);
        
                return View(about);
            }
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutWebDto dto, string id)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
        
            var response = await client.PutAsync($"http://localhost:5026/api/Abouts/{id}", content);
        
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
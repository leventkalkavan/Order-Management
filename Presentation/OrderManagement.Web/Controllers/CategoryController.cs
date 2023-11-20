using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.CategoryDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderManagement.Web.DTOs;

namespace OrderManagement.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5026/api/Category");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                //listelerken deserialize, eklerken serialize
                var values = JsonConvert.DeserializeObject<List<ResultCategoryWebDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryWebDto createCategoryWebDto)
        {
            createCategoryWebDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryWebDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5026/api/Category", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:5026/api/Category/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        
        public async Task<IActionResult> UpdateCategory(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5026/api/Category/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var category = JsonConvert.DeserializeObject<UpdateCategoryWebDto>(jsonData);

                return View(category);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryWebDto dto, string id)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"http://localhost:5026/api/Category/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
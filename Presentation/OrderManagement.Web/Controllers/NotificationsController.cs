using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderManagement.Web.DTOs.AboutWebDto;
using OrderManagement.Web.DTOs.NotificationWebDto;

namespace OrderManagement.Web.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5026/api/Notifications");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultNotificationWebDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        
        [HttpGet]
        public IActionResult CreateNotification()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationWebDto createNotificationWebDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createNotificationWebDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5026/api/Notifications", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        
        public async Task<IActionResult> DeleteNotification(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:5026/api/Notifications/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        
        [HttpGet]
        public async Task<IActionResult> UpdateNotification(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5026/api/Notifications/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var notification = JsonConvert.DeserializeObject<UpdateNotificationWebDto>(jsonData);

                return View(notification);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationWebDto dto, string id)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"http://localhost:5026/api/Notifications/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> NotificationStatusChangeToStatusTrue(string id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"http://localhost:5026/api/Notifications/NotificationStatusChangeToStatusTrue/{id}");
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> NotificationStatusChangeToStatusFalse(string id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"http://localhost:5026/api/Notifications/NotificationStatusChangeToStatusFalse/{id}");
            return RedirectToAction("Index");
        }

    }
}
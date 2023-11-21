using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderManagement.Web.DTOs.AboutWebDto;
using OrderManagement.Web.DTOs.ContactWebDto;

namespace OrderManagement.Web.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
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
        
        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactWebDto createContactWebDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactWebDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5026/api/Contacts", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        
        public async Task<IActionResult> DeleteContact(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:5026/api/Contacts/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        
        public async Task<IActionResult> UpdateContact(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5026/api/Contacts/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var contact = JsonConvert.DeserializeObject<UpdateContactWebDto>(jsonData);

                return View(contact);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactWebDto dto, string id)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"http://localhost:5026/api/Contacts/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
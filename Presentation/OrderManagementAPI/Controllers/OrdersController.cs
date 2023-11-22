using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.OrderDto;
using Application.Repositories.OrderRepositoires;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;

        public OrdersController(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository)
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
        }

        [HttpGet]
        public IActionResult AllOrders()
        {
            return Ok(_orderReadRepository.GetAll());
        }
        
        //tum siparisleri getirir
        [HttpGet("GetOrderCount")]
        public IActionResult GetOrderCount()
        {
            return Ok(_orderReadRepository.GetAll().Count());
        }
        //tum siparislerin gelirini getirir
        [HttpGet("GetOrderTotalPrice")]
        public IActionResult GetOrderPriceCount()
        {
            return Ok(_orderReadRepository.GetAll().Sum(x => x.TotalPrice));
        }
        
        //son siparisi gosterir
        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            return Ok(_orderReadRepository.GetAll().OrderByDescending(x=>x.Id).Take(1)
                .Select(x=>x.TotalPrice).FirstOrDefault());
        }
        
        //aktif siparisleri gosterir
        [HttpGet("GetActiveOrderCount")]
        public IActionResult GetActiveOrderCount()
        {
            return Ok(_orderReadRepository.GetAll().Count(x => x.Status == true));
        }
        
        //gun icindeki kazancı gosterir
        [HttpGet("GetTodayTotalPrice")]
        public IActionResult GetTodayTotalPrice()
        {
            DateTime today = DateTime.Today;
            decimal totalAmount = _orderReadRepository
                .GetAll()
                .Where(x => x.Date.Date == today)
                .Sum(x => x.TotalPrice);
            return Ok(totalAmount);
        }
        
        //siparis ekler
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto order)
        {
            var req = new Order()
            {
                Status = true,
                TableNumber = order.TableNumber,
                TotalPrice = order.TotalPrice,
                Date = DateTime.Now
            };
            await _orderWriteRepository.AddAsync(req);
            await _orderWriteRepository.SaveAsync();
            return Ok();
        }
    }
}

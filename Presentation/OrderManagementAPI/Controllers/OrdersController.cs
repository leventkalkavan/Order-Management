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
        private readonly IOrderReadRepositoires _orderReadRepositoires;
        private readonly IOrderWriteRepositoires _orderWriteRepositoires;

        public OrdersController(IOrderReadRepositoires orderReadRepositoires, IOrderWriteRepositoires orderWriteRepositoires)
        {
            _orderReadRepositoires = orderReadRepositoires;
            _orderWriteRepositoires = orderWriteRepositoires;
        }

        [HttpGet]
        public IActionResult AllOrders()
        {
            return Ok(_orderReadRepositoires.GetAll());
        }

        [HttpGet("GetOrderCount")]
        public IActionResult GetOrderCount()
        {
            return Ok(_orderReadRepositoires.GetAll().Count());
        }

        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            return Ok(_orderReadRepositoires.GetAll().OrderByDescending(x=>x.Id).Take(1)
                .Select(x=>x.TotalPrice).FirstOrDefault());
        }
        
        [HttpGet("GetActiveOrderCount")]
        public IActionResult GetActiveOrderCount()
        {
            return Ok(_orderReadRepositoires.GetAll().Count(x => x.Status == true));
        }
        
        [HttpGet("GetTodayTotalPrice")]
        public IActionResult DailyEarnings()
        {
            DateTime today = DateTime.Today;
            decimal totalAmount = _orderReadRepositoires
                .GetAll()
                .Where(x => x.Date.Date == today)
                .Sum(x => x.TotalPrice);
            return Ok(totalAmount);
        }
        
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
            await _orderWriteRepositoires.AddAsync(req);
            await _orderWriteRepositoires.SaveAsync();
            return Ok();
        }
    }
}

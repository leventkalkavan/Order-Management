using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.OrderRepositoires;
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

        // yazılanı aldım direkt bool tutulup donulebilir
        //
        // [HttpGet("GetActiveOrderCount")]
        // public IActionResult GetActiveOrderCount()
        // {
        //     return Ok(_orderReadRepositoires.GetAll().Where(x => x.Description == "musteri masada").Count());
        // }
    }
}

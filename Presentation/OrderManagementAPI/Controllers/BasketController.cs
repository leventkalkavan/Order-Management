using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.BasketDto;
using Application.Repositories.BasketRepositories;
using Application.Repositories.ProductRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketReadRepository _basketReadRepository;
        private readonly IBasketWriteRepository _basketWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public BasketController(IBasketReadRepository basketReadRepository, IBasketWriteRepository basketWriteRepository, IProductReadRepository productReadRepository)
        {
            _basketReadRepository = basketReadRepository;
            _basketWriteRepository = basketWriteRepository;
            _productReadRepository = productReadRepository;
        }
        
        //masa idye gore sepeti getirir
        [HttpGet]
        public IActionResult GetBasketByMenuTableId(Guid id)
        {
            return Ok(_basketReadRepository.GetAll().Where(x=>x.MenuTableId == id).Include(y=>y.Product).ToList());
        }
        
        //yeni sepet ekler
        [HttpPost]
        public async Task<IActionResult> CreateBasket([FromBody]CreateBasketDto dto)
        {
            var basket = new Basket()
            {
                ProductId = dto.ProductId,
                Price = _productReadRepository.GetAll().Where(x => x.Id == dto.ProductId).Select(x => x.Price).FirstOrDefault(),
                Count = 1,
                MenuTableId = new Guid("34f1d5d7-fcc5-4f6b-a288-eb08dfd4063c"),
                TotalPrice = 0
            };
            await _basketWriteRepository.AddAsync(basket);
            await _basketWriteRepository.SaveAsync();
            return Ok();
        }

        
        //masaidye gore sepetin icinde productnamei alır
        [HttpGet("GetBasketWithProductName")]
        public IActionResult GetBasketWithProductName(Guid id)
        {
            var basketsWithProductNames = _basketReadRepository
                .GetAll()
                .Where(x => x.MenuTableId == id)
                .Include(y => y.Product)
                .Select(basket => new
                {
                    basket.Id,
                    basket.ProductId,
                    basket.Price,
                    basket.Count,
                    basket.TotalPrice,
                    basket.MenuTableId,
                    ProductName = basket.Product.Name
                })
                .ToList();

            return Ok(basketsWithProductNames);
        }
        
        //sepeti siler
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasket(string id)
        {
            await _basketWriteRepository.RemoveAsync(id);
            await _basketWriteRepository.SaveAsync();
            return Ok();
        }
    }
}

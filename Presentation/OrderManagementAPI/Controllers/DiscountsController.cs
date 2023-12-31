using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.DiscountDto;
using Application.Repositories.DiscountRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountReadRepository _discountReadRepository;
        private readonly IDiscountWriteRepository _discountWriteRepository;

        public DiscountsController(IDiscountReadRepository discountReadRepository,
            IDiscountWriteRepository discountWriteRepository)
        {
            _discountReadRepository = discountReadRepository;
            _discountWriteRepository = discountWriteRepository;
        }

        [HttpGet]
        public IActionResult AllDiscount()
        {
            return Ok(_discountReadRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscount(string id)
        {
            return Ok(await _discountReadRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto dto)
        {
            var discount = new Discount()
            {
                Status = true,
                Description = dto.Description,
                Amount = dto.Amount,
                ImageUrl = dto.ImageUrl,
                Title = dto.Title
            };
            await _discountWriteRepository.AddAsync(discount);
            await _discountWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscount(string id)
        {
            await _discountWriteRepository.RemoveAsync(id);
            await _discountWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto dto)
        {
            var discount = await _discountReadRepository.GetByIdAsync(dto.Id);
            discount.Amount = dto.Amount;
            discount.Description = dto.Description;
            discount.ImageUrl = dto.ImageUrl;
            discount.Title = dto.Title;
            discount.UpdatedDate = DateTime.Now;
            _discountWriteRepository.Update(discount);
            await _discountWriteRepository.SaveAsync();
            return Ok();
        }
        
        
        //durumu trueya çevirir
        [HttpGet("ChangeStatusToTrue/{id}")]
        public async Task<IActionResult> ChangeStatusToTrue(string id)
        {
            var discount = await _discountReadRepository.GetByIdAsync(id);
            discount.Status = true;
            await _discountWriteRepository.SaveAsync();
            return Ok("discount description approved");
        }
        //rezarvasyonu iptal eder
        [HttpGet("ChangeStatusToFalse/{id}")]
        public async Task<IActionResult> ChangeStatusToFalse(string id)
        {
            var discount = await _discountReadRepository.GetByIdAsync(id);
            discount.Status = false;
            await _discountWriteRepository.SaveAsync();
            return Ok("discount description cancelled");
        }
    }
}
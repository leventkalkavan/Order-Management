using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.ProductDto;
using Application.Repositories.ProductRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository,
            IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        
        [HttpGet]
        public IActionResult AllProduct()
        {
            return Ok(_productReadRepository.GetAll());
        }
        
        [HttpGet("GetProductCountByCategory")]
        public IActionResult GetProductCountByCategory(string categoryName)
        {
            return Ok(_productReadRepository.GetAll().Count(x => x.Category.Name == categoryName));
        }


        [HttpGet("GetMostCheapProduct")]
        public IActionResult GetMostCheapProduct()
        {
            return Ok(_productReadRepository.GetAll()
                .OrderBy(x => x.Price)
                .Select(x => x.Name)
                .FirstOrDefault());
        }

        [HttpGet("GetMostExpensiveProduct")]
        public IActionResult GetMostExpensiveProduct()
        {
            return Ok(_productReadRepository.GetAll()
                .OrderByDescending(x => x.Price)
                .Select(x => x.Name)
                .FirstOrDefault());
        }

        [HttpGet("GetAveragePriceByCategory")]
        public IActionResult GetAveragePriceByCategory(string categoryName)
        {
            var productsInCategory = _productReadRepository.GetAll()
                .Where(x => x.Category.Name == categoryName)
                .ToList();

            if (productsInCategory.Any())
            {
                decimal averagePrice = productsInCategory.Average(x => x.Price);
                return Ok(averagePrice);
            }
            return NotFound($"No products found in the category: {categoryName}");
        }

        [HttpGet("GetProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var productsWithCategories = _productReadRepository.GetAll().Include(p => p.Category)
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    Status = p.Status,
                    CategoryName = p.Category.Name
                })
                .ToList();
            return Ok(productsWithCategories);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            var product = new Product()
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl,
                CategoryId = dto.CategoryId,
                Status = true
            };
            await _productWriteRepository.AddAsync(product);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {
            var product = await _productReadRepository.GetByIdAsync(dto.Id);
            product.Name = dto.Name;
            product.Status = dto.Status;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.ImageUrl = dto.ImageUrl;
            product.UpdatedDate = DateTime.Now;
            _productWriteRepository.Update(product);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
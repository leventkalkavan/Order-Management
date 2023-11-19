using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.CategoryDto;
using Application.Repositories.CategoryRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public CategoryController(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
        }

        [HttpGet]
        public IActionResult AllCategory()
        {
            return Ok(_categoryReadRepository.GetAll());
        }

        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory(string id)
        {
            return Ok(await _categoryReadRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
            var category = new Category()
            {
                Name = dto.Name,
                Status = true
            };
            await _categoryWriteRepository.AddAsync(category);
            await _categoryWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryWriteRepository.RemoveAsync(id);
            await _categoryWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
        {
            var category = await _categoryReadRepository.GetByIdAsync(dto.Id);
            category.Name = dto.Name;
            category.Status = dto.Status;
            category.UpdatedDate= DateTime.Now;
            _categoryWriteRepository.Update(category);
            await _categoryWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
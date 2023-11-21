using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.ReferenceDto;
using Application.Repositories.ReferenceRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferencesController : ControllerBase
    {
        private readonly IReferenceReadRepository _referenceReadRepository;
        private readonly IReferenceWriteRepository _referenceWriteRepository;

        public ReferencesController(IReferenceReadRepository referenceReadRepository,
            IReferenceWriteRepository referenceWriteRepository)
        {
            _referenceReadRepository = referenceReadRepository;
            _referenceWriteRepository = referenceWriteRepository;
        }

        [HttpGet]
        public IActionResult AllReference()
        {
            return Ok(_referenceReadRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReference(string id)
        {
            return Ok(await _referenceReadRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateReference(CreateReferenceDto dto)
        {
            var reference = new Reference()
            {
                Name = dto.Name,
                Title = dto.Title,
                Comment = dto.Comment,
                ImageUrl = dto.ImageUrl,
                Status = true
            };
            await _referenceWriteRepository.AddAsync(reference);
            await _referenceWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReference(string id)
        {
            await _referenceWriteRepository.RemoveAsync(id);
            await _referenceWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReference(UpdateReferenceDto dto)
        {
            var reference = await _referenceReadRepository.GetByIdAsync(dto.Id);
            reference.Name = dto.Name;
            reference.Status = dto.Status;
            reference.Title = dto.Title;
            reference.Comment = dto.Comment;
            reference.ImageUrl = dto.ImageUrl;
            reference.UpdatedDate = DateTime.Now;
            _referenceWriteRepository.Update(reference);
            await _referenceWriteRepository.SaveAsync();
            return Ok();
        }
    }
}

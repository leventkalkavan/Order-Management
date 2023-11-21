using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.FeatureDto;
using Application.Repositories.FeatureRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureReadRepository _featureReadRepository;
        private readonly IFeatureWriteRepository _featureWriteRepository;

        public FeaturesController(IFeatureReadRepository featureReadRepository,
            IFeatureWriteRepository featureWriteRepository)
        {
            _featureReadRepository = featureReadRepository;
            _featureWriteRepository = featureWriteRepository;
        }

        [HttpGet]
        public IActionResult AllFeature()
        {
            return Ok(_featureReadRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(string id)
        {
            return Ok(await _featureReadRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto dto)
        {
            var feature = new Feature()
            {
                Title = dto.Title,
                Title2 = dto.Title2,
                Title3 = dto.Title3,
                Description = dto.Description,
                Description2 = dto.Description2,
                Description3 = dto.Description3
            };
            await _featureWriteRepository.AddAsync(feature);
            await _featureWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureWriteRepository.RemoveAsync(id);
            await _featureWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto dto)
        {
            var feature = await _featureReadRepository.GetByIdAsync(dto.Id);
            feature.Title = dto.Title;
            feature.Title2 = dto.Title2;
            feature.Title3 = dto.Title3;
            feature.Description = dto.Description;
            feature.Description2 = dto.Description2;
            feature.Description3 = dto.Description3;
            feature.UpdatedDate = DateTime.Now;
            _featureWriteRepository.Update(feature);
            await _featureWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
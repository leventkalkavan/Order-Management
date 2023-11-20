using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.SocialMediaDto;
using Application.Repositories.SocialMediaRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaReadRepository _socialMediaReadRepository;
        private readonly ISocialMediaWriteRepository _socialMediaWriteRepository;

        public SocialMediaController(ISocialMediaReadRepository socialMediaReadRepository,
            ISocialMediaWriteRepository socialMediaWriteRepository)
        {
            _socialMediaReadRepository = socialMediaReadRepository;
            _socialMediaWriteRepository = socialMediaWriteRepository;
        }

        [HttpGet]
        public IActionResult AllSocialMedia()
        {
            return Ok(_socialMediaReadRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMedia(string id)
        {
            return Ok(await _socialMediaReadRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto dto)
        {
            var socialMedia = new SocialMedia()
            {
                Url = dto.Url,
                Title = dto.Title,
                Icon = dto.Icon
            };
            await _socialMediaWriteRepository.AddAsync(socialMedia);
            await _socialMediaWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialMedia(string id)
        {
            await _socialMediaWriteRepository.RemoveAsync(id);
            await _socialMediaWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto dto)
        {
            var socialMedia = await _socialMediaReadRepository.GetByIdAsync(dto.Id);
            socialMedia.Url = dto.Url;
            socialMedia.Icon = dto.Icon;
            socialMedia.Title = dto.Title;
            socialMedia.UpdatedDate = DateTime.Now;
            _socialMediaWriteRepository.Update(socialMedia);
            await _socialMediaWriteRepository.SaveAsync();
            return Ok();
        }
    }
}

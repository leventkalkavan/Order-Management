
using Application.DTOs.AboutDto;
using Application.Repositories.AboutRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutReadRepository _aboutReadRepository;
        private readonly IAboutWriteRepository _aboutWriteRepository;

        public AboutController(IAboutReadRepository aboutReadRepository, IAboutWriteRepository aboutWriteRepository)
        {
            _aboutReadRepository = aboutReadRepository;
            _aboutWriteRepository = aboutWriteRepository;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            return Ok(_aboutReadRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto dto)
        {
            About about = new About()
            {
                Title = dto.Title,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl
            };
            await _aboutWriteRepository.AddAsync(about);
            await _aboutWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutWriteRepository.RemoveAsync(id);
            await _aboutWriteRepository.SaveAsync();
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto dto)
        {
            var about = await _aboutReadRepository.GetByIdAsync(dto.Id);
            about.Description = dto.Description;
            about.Title = dto.Title;
            about.ImageUrl = dto.ImageUrl;
            about.UpdatedDate = DateTime.Now;
            _aboutWriteRepository.Update(about);
            await _aboutWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpGet("GetAbout")]
        public async Task<IActionResult> GetAbout(string id)
        {
            var about = await _aboutReadRepository.GetByIdAsync(id);
            return Ok(about);
        }

        
    }
}

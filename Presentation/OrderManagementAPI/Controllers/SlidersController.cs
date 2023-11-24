using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.SliderRepositories;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderReadRepository _sliderReadRepository;
        private readonly ISliderWriteRepository _sliderWriteRepository;

        public SlidersController(ISliderReadRepository sliderReadRepository, ISliderWriteRepository sliderWriteRepository)
        {
            _sliderReadRepository = sliderReadRepository;
            _sliderWriteRepository = sliderWriteRepository;
        }

        [HttpGet]
        public IActionResult GetAllSliders()
        {
            return Ok(_sliderReadRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(Slider slider)
        {
            var createSlider = new Slider()
            {
                Description1 = slider.Description1,
                Description2 = slider.Description2,
                Description3 = slider.Description3,
                Title1 = slider.Title1,
                Title2 = slider.Title2,
                Title3 = slider.Title3
            };
            await _sliderWriteRepository.AddAsync(createSlider);
            await _sliderWriteRepository.SaveAsync();
            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.BookingDto;
using Application.Repositories.BookingRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingReadRepository _bookingReadRepository;
        private readonly IBookingWriteRepository _bookingWriteRepository;

        public BookingsController(IBookingReadRepository bookingReadRepository,
            IBookingWriteRepository bookingWriteRepository)
        {
            _bookingReadRepository = bookingReadRepository;
            _bookingWriteRepository = bookingWriteRepository;
        }

        [HttpGet]
        public IActionResult AllBooking()
        {
            return Ok(_bookingReadRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(string id)
        {
            return Ok(await _bookingReadRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto dto)
        {
            if (dto.Date.Date < DateTime.Today)
            {
                return BadRequest();
            }

            var booking = new Booking()
            {
                Email = dto.Email,
                Name = dto.Name,
                Telephone = dto.Telephone,
                Date = dto.Date,
                PersonCount = dto.PersonCount
            };

            await _bookingWriteRepository.AddAsync(booking);
            await _bookingWriteRepository.SaveAsync();

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(string id)
        {
            await _bookingWriteRepository.RemoveAsync(id);
            await _bookingWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto dto)
        {
            if (dto.Date.Date < DateTime.Today)
            {
                return BadRequest();
            }

            var booking = await _bookingReadRepository.GetByIdAsync(dto.Id);
            booking.Email = dto.Email;
            booking.Name = dto.Name;
            booking.Telephone = dto.Telephone;
            booking.PersonCount = dto.PersonCount;
            booking.Date = dto.Date;
            booking.UpdatedDate = DateTime.Now;
            _bookingWriteRepository.Update(booking);
            await _bookingWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
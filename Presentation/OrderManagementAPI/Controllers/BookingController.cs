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
    public class BookingController : ControllerBase
    {
        private readonly IBookingReadRepository _bookingReadRepository;
        private readonly IBookingWriteRepository _bookingWriteRepository;

        public BookingController(IBookingReadRepository bookingReadRepository,
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

        [HttpGet("GetBooking")]
        public async Task<IActionResult> GetBooking(string id)
        {
            return Ok(await _bookingReadRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto dto)
        {
            var booking = new Booking()
            {
                Email = dto.Email,
                Name = dto.Name,
                Telephone = dto.Telephone,
                PersonCount = dto.PersonCount
            };
            await _bookingWriteRepository.AddAsync(booking);
            await _bookingWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBooking(string id)
        {
            await _bookingWriteRepository.RemoveAsync(id);
            await _bookingWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto dto)
        {
            var booking = await _bookingReadRepository.GetByIdAsync(dto.Id);
            booking.Email = dto.Email;
            booking.Name = dto.Name;
            booking.Telephone = dto.Telephone;
            booking.PersonCount = dto.PersonCount;
            booking.UpdatedDate = DateTime.Now;
            _bookingWriteRepository.Update(booking);
            await _bookingWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
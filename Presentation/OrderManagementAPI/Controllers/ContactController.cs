using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.ContactDto;
using Application.Repositories.ContactRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactReadRepository _contactReadRepository;
        private readonly IContactWriteRepository _contactWriteRepository;

        public ContactController(IContactReadRepository contactReadRepository,
            IContactWriteRepository contactWriteRepository)
        {
            _contactReadRepository = contactReadRepository;
            _contactWriteRepository = contactWriteRepository;
        }

        [HttpGet]
        public IActionResult AllContact()
        {
            return Ok(_contactReadRepository.GetAll());
        }

        [HttpGet("GetContact")]
        public async Task<IActionResult> GetContact(string id)
        {
            return Ok(await _contactReadRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto dto)
        {
            var contact = new Contact()
            {
                Location = dto.Location,
                Mail = dto.Mail,
                FooterDescription = dto.FooterDescription
            };
            await _contactWriteRepository.AddAsync(contact);
            await _contactWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContact(string id)
        {
            await _contactWriteRepository.RemoveAsync(id);
            await _contactWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactDto dto)
        {
            var contact = await _contactReadRepository.GetByIdAsync(dto.Id);
            contact.Location = dto.Location;
            contact.Mail = dto.Mail;
            contact.FooterDescription = dto.FooterDescription;
            contact.UpdatedDate = DateTime.Now;
            _contactWriteRepository.Update(contact);
            await _contactWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
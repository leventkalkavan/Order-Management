using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.MenuTableDto;
using Application.Repositories.MenuTableRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableReadRepository _menuTableReadRepository;
        private readonly IMenuTableWriteRepository _menuTableWriteRepository;

        public MenuTablesController(IMenuTableReadRepository menuTableReadRepository, IMenuTableWriteRepository menuTableWriteRepository)
        {
            _menuTableReadRepository = menuTableReadRepository;
            _menuTableWriteRepository = menuTableWriteRepository;
        }
        
        //toplam masa sayisini getirir
        [HttpGet("GetMenuTableCount")]
        public IActionResult GetMenuTableCount()
        {
            return Ok(_menuTableReadRepository.GetAll().Count());
        }
        
        //tum masa sayisini getirir
        [HttpGet("GetAllMenuTable")]
        public IActionResult GetAllMenuTable()
        {
            return Ok(_menuTableReadRepository.GetAll());
        }
        
        //masa ekler
        [HttpPost]
        public async Task<IActionResult> CreateMenuTable(CreateMenuTableDto dto)
        {
            var table = new MenuTable()
            {
                Status = false,
                Name = dto.Name
            };
            await _menuTableWriteRepository.AddAsync(table);
            await _menuTableWriteRepository.SaveAsync();
            return Ok();
        }
        
        //menutable'i siler
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuTable(string id)
        {
            await _menuTableWriteRepository.RemoveAsync(id);
            await _menuTableWriteRepository.SaveAsync();
            return Ok();
        }

        //menutable'i gunceller
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeleteMenuTable(UpdateMenuTableDto dto)
        {
            var menuTable = await _menuTableReadRepository.GetByIdAsync(dto.Id);
            menuTable.Status = false;
            menuTable.Name = dto.Name;
            _menuTableWriteRepository.Update(menuTable);
            await _menuTableWriteRepository.SaveAsync();
            return Ok();
        }
    }
}

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
        
        [HttpGet("GetMenuTableCount")]
        public IActionResult GetMenuTableCount()
        {
            return Ok(_menuTableReadRepository.GetAll().Count());
        }

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
    }
}
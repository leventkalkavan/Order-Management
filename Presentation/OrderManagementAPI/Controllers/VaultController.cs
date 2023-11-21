using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.VaultDto;
using Application.Repositories.VaultRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaultController : ControllerBase
    {
        private readonly IVaultReadRepository _vaultReadRepository;
        private readonly IVaultWriteRepository _vaultWriteRepository;

        public VaultController(IVaultReadRepository vaultReadRepository, IVaultWriteRepository vaultWriteRepository)
        {
            _vaultReadRepository = vaultReadRepository;
            _vaultWriteRepository = vaultWriteRepository;
        }

        [HttpGet("TotalVaultAmount")]
        public IActionResult TotalVaultAmount()
        {
            decimal totalAmount = _vaultReadRepository
                .GetAll()
                .Sum(x => x.TotalAmount);

            return Ok(totalAmount);
        }


        [HttpGet("GetDailyEarnings")]
        public IActionResult DailyEarnings()
        {
            DateTime today = DateTime.Today;
            decimal totalAmount = _vaultReadRepository
                .GetAll()
                .Where(x => x.CreatedDate.Date == today)
                .Sum(x => x.TotalAmount);
            return Ok(totalAmount);
        }


        [HttpPost]
        public async Task<IActionResult> CreateVault(CreateVault dto)
        {
            var vault = new Vault()
            {
                TotalAmount = dto.TotalAmount
            };
            await _vaultWriteRepository.AddAsync(vault);
            await _vaultWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
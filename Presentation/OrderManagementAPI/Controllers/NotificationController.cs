using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.NotificationDto;
using Application.Repositories.NotificationRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationReadRepository _notificationReadRepository;
        private readonly INotificationWriteRepository _notificationWriteRepository;

        public NotificationController(INotificationReadRepository notificationReadRepository, INotificationWriteRepository notificationWriteRepository)
        {
            _notificationReadRepository = notificationReadRepository;
            _notificationWriteRepository = notificationWriteRepository;
        }
        
        //tum bildirimlei listeler
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_notificationReadRepository.GetAll());
        }
        
        //statusu false olan bildirimlerin sayısını getitir
        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationReadRepository.GetAll().Count(x => x.Status==false));
        }
        
        
        //statusu false olan bildirimleri listeler
        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            return Ok(_notificationReadRepository.GetAll().Where(x => x.Status == false).ToList());
        }
        
        //yeni bildirim ekler
        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto dto)
        {
            var value = new Notification()
            {
                Date = DateTime.Now,
                Description = dto.Description,
                Status = false
            };
            await _notificationWriteRepository.AddAsync(value);
            await _notificationWriteRepository.SaveAsync();
            return Ok();
        }
    }
}

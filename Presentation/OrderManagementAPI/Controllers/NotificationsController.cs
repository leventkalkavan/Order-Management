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
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationReadRepository _notificationReadRepository;
        private readonly INotificationWriteRepository _notificationWriteRepository;

        public NotificationsController(INotificationReadRepository notificationReadRepository, INotificationWriteRepository notificationWriteRepository)
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
        
        //bildirim silme
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(string id)
        {
            await _notificationWriteRepository.RemoveAsync(id);
            await _notificationWriteRepository.SaveAsync();
            return Ok();
        }
        
        //bildirim guncelleme
        [HttpPut("UpdateNotification/{id}")]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationDto dto)
        {
            var notification = await _notificationReadRepository.GetByIdAsync(dto.Id);
            notification.Description = dto.Description;
            notification.UpdatedDate = DateTime.Now;
            _notificationWriteRepository.Update(notification);
            await _notificationWriteRepository.SaveAsync();
            return Ok();
        }
        
        //notifictionun durumunu falsetan true yapar
        [HttpGet("NotificationStatusChangeToStatusTrue/{id}")]
        public async Task<IActionResult> NotificationStatusChangeToStatusTrue(string id)
        {
            var notf = await _notificationReadRepository.GetByIdAsync(id);
            notf.Status = true;
            _notificationWriteRepository.Update(notf);
            await _notificationWriteRepository.SaveAsync();
            return Ok();
        }
        //notifictionun durumunu truedan false yapar
        [HttpGet("NotificationStatusChangeToStatusFalse/{id}")]
        public async Task<IActionResult> NotificationStatusChangeToStatusFalse(string id)
        {
            var notf = await _notificationReadRepository.GetByIdAsync(id);
            notf.Status = false;
            _notificationWriteRepository.Update(notf);
            await _notificationWriteRepository.SaveAsync();
            return Ok();
        }
    }
}

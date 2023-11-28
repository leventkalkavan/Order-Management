using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using OrderManagement.Web.DTOs.MailsWebDto;

namespace OrderManagement.Web.Controllers
{
    [Authorize]
    public class MailsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(CreateMailWebDto dto)
        {
            MimeMessage mimeMessage = new MimeMessage();
    
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Lezzet Köşesi Restoran", "testoglutestcan@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddress = new MailboxAddress("User", dto.ReceiverMail);
            mimeMessage.To.Add(mailboxAddress);

            var bodybuilder = new BodyBuilder();
            bodybuilder.HtmlBody = dto.Body; // HTML içeriği bu şekilde ayarlanıyor
            mimeMessage.Body = bodybuilder.ToMessageBody();

            mimeMessage.Subject = dto.Subject;

            SmtpClient client = new SmtpClient();
    
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("testoglutestcan@gmail.com", "iqbx qufc mekv avgb");
    
            client.Send(mimeMessage);
            client.Disconnect(true);
    
            return RedirectToAction("Index", "Categories");
        }

    }
}
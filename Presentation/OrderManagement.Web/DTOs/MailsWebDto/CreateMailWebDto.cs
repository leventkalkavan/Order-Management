namespace OrderManagement.Web.DTOs.MailsWebDto;

public class CreateMailWebDto
{
    public string ReceiverMail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}
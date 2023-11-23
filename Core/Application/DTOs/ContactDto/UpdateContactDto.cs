namespace Application.DTOs.ContactDto;

public class UpdateContactDto
{
    public string Id { get; set; }
    public string Location { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public string FooterTitle { get; set; }
    public string FooterDescription { get; set; }
    public string OpenDays { get; set; }
    public string OpenHour { get; set; }
}
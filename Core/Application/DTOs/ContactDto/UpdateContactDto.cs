namespace Application.DTOs.ContactDto;

public class UpdateContactDto
{
    public string Id { get; set; }
    public string Location { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public DateTime UpdatedDate { get; set; }
}
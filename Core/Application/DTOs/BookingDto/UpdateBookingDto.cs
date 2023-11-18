namespace Application.DTOs.BookingDto;

public class UpdateBookingDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string Email { get; set; }
    public int PersonCount { get; set; }
    public DateTime Date { get; set; }
}
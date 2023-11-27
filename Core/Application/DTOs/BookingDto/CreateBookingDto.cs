namespace Application.DTOs.BookingDto;

public class CreateBookingDto
{
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string? Description { get; set; }
    public string? Email { get; set; }
    public DateTime Date { get; set; }
    public int PersonCount { get; set; }
}
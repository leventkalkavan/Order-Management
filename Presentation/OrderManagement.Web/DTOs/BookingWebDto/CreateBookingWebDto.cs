namespace OrderManagement.Web.DTOs.BookingWebDto;

public class CreateBookingWebDto
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Telephone { get; set; }
    public string? Email { get; set; }
    public int PersonCount { get; set; }
}
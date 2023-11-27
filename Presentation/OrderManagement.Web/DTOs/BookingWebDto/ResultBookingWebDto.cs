namespace OrderManagement.Web.DTOs.BookingWebDto;

public class ResultBookingWebDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
    public int PersonCount { get; set; }
    public DateTime Date { get; set; }
}
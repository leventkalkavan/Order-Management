namespace Application.DTOs.OrderDto;

public class CreateOrderDto
{
    public string TableNumber { get; set; }
    public bool Status { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalPrice { get; set; }
}
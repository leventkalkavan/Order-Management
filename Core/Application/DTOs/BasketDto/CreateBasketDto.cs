namespace Application.DTOs.BasketDto;

public class CreateBasketDto
{
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
    public decimal Count { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid MenuTableId { get; set; }
}
namespace OrderManagement.Web.DTOs.BasketWebDto;

public class ResultBasketWebDto
{
    public string Id { get; set; }
    public decimal Price { get; set; }
    public decimal Count { get; set; }
    public decimal TotalPrice { get; set; }
    public string ProductName { get; set; }
}
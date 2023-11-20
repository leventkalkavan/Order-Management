namespace OrderManagement.Web.DTOs.ProductWebDto;

public class ResultProductWebDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }
    public string CategoryName { get; set; }
    public decimal Price { get; set; }
}
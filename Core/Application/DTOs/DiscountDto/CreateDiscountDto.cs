namespace Application.DTOs.DiscountDto;

public class CreateDiscountDto
{
    public string Title { get; set; }
    public string Amount { get; set; }
    public bool Status { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}
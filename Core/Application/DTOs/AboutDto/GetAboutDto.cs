namespace Application.DTOs.AboutDto;

public class GetAboutDto
{
    public string Id { get; set; }
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string Description { get; set; }
}
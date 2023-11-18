using Microsoft.AspNetCore.Http;

namespace Application.DTOs.AboutDto;

public class CreateAboutDto
{
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    // public IFormFile? Image { get; set; }
    public string Description { get; set; }
}
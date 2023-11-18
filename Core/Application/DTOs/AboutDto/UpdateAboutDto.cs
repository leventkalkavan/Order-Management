using Microsoft.AspNetCore.Http.Internal;

namespace Application.DTOs.AboutDto;

public class UpdateAboutDto
{
    public string Id { get; set; }
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
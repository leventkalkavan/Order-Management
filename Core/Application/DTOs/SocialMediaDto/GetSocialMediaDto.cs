namespace Application.DTOs.SocialMediaDto;

public class GetSocialMediaDto
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
namespace Application.DTOs.ReferenceDto;

public class UpdateReferenceDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }
    public DateTime UpdatedDate { get; set; }
}
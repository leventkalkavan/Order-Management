namespace Application.DTOs.CategoryDto;

public class UpdateCategoryDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
    public DateTime UpdatedDate { get; set; }
}
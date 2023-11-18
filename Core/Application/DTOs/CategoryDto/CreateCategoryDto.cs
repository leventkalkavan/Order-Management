namespace Application.DTOs.CategoryDto;

public class CreateCategoryDto
{
    public string Name { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
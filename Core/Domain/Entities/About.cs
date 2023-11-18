using Domain.Entities.Common;

namespace Domain.Entities;

public class About: BaseEntity
{
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
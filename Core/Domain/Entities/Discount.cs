using Domain.Entities.Common;

namespace Domain.Entities;

public class Discount: BaseEntity
{
    public string Title { get; set; }
    public string Amount { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public string ImageUrl { get; set; }
}
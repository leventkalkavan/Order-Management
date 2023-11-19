using Domain.Entities.Common;

namespace Domain.Entities;

public class Category: BaseEntity
{
    public string Name { get; set; }
    public bool Status { get; set; }
    public List<Product> Products { get; set; }
}
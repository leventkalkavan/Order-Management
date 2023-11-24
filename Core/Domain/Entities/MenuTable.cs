using Domain.Entities.Common;

namespace Domain.Entities;

public class MenuTable: BaseEntity
{
    public string Name { get; set; }
    public bool Status { get; set; }
    public List<Basket> Baskets { get; set; }
}
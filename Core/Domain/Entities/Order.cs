using Domain.Entities.Common;

namespace Domain.Entities;

public class Order: BaseEntity
{
    public string TableNumber { get; set; }
    public bool Status { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
}
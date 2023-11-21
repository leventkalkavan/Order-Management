using Domain.Entities.Common;

namespace Domain.Entities;

public class OrderDetail: BaseEntity
{
    public string ProductId { get; set; }
    public Product Product { get; set; }
    public int Count { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public string OrderId { get; set; }
    public Order Order { get; set; }
}
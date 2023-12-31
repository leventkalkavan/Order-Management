using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Common;
using Microsoft.AspNetCore.Http;

namespace Domain.Entities;

public class Product: BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    [Column(TypeName ="decimal(18,2)")]
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public bool Status { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
    public List<Basket> Baskets { get; set; }
}
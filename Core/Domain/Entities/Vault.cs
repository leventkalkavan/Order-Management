using Domain.Entities.Common;

namespace Domain.Entities;

public class Vault: BaseEntity
{
    public decimal TotalAmount { get; set; }
}
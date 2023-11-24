using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Basket : BaseEntity
    {
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid MenuTableId { get; set; }

        public Product Product { get; set; }
        public MenuTable MenuTable { get; set; }
    }
}
using Application.Repositories.OrderDetailRepositoires;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.OrderDetailRepositoires;

public class OrderDetailReadRepository: ReadRepository<OrderDetail>, IOrderDetailReadRepositoires
{
    public OrderDetailReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
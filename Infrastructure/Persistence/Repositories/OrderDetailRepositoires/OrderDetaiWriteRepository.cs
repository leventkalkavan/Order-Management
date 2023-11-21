using Application.Repositories.OrderDetailRepositoires;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.OrderDetailRepositoires;

public class OrderDetaiWriteRepository: WriteRepository<OrderDetail>, IOrderDetailWriteRepositoires
{
    public OrderDetaiWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
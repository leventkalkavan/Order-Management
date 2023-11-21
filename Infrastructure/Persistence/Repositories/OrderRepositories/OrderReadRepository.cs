using Application.Repositories.OrderRepositoires;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.OrderRepositories;

public class OrderReadRepository: ReadRepository<Order>, IOrderReadRepositoires
{
    public OrderReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
using Application.Repositories.OrderRepositoires;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.OrderRepositories;

public class OrderReadRepository: ReadRepository<Order>, IOrderReadRepository
{
    public OrderReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
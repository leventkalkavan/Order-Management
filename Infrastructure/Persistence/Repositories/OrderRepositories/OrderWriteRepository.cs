using Application.Repositories.OrderRepositoires;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.OrderRepositories;

public class OrderWriteRepository: WriteRepository<Order>, IOrderWriteRepositoires
{
    public OrderWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
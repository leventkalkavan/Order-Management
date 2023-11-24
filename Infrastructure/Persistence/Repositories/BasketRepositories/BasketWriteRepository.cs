using Application.Repositories.BasketRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.BasketRepositories;

public class BasketWriteRepository: WriteRepository<Basket>, IBasketWriteRepository
{
    public BasketWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
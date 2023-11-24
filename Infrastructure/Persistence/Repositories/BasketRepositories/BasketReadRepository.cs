using Application.Repositories;
using Application.Repositories.BasketRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.BasketRepositories;

public class BasketReadRepository: ReadRepository<Basket>, IBasketReadRepository
{
    public BasketReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
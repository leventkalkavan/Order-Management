using Application.Repositories.DiscountRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.DiscountRepositories;

public class DiscountReadRepository: ReadRepository<Discount>, IDiscountReadRepository
{
    public DiscountReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
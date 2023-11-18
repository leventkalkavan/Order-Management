using Application.Repositories;
using Application.Repositories.DiscountRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.DiscountRepositories;

public class DiscountWriteRepository: WriteRepository<Discount>, IDiscountWriteRepository
{
    public DiscountWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
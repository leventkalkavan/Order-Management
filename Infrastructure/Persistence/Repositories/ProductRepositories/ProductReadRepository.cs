using Application.Repositories.ProductRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.ProductRepositories;

public class ProductReadRepository: ReadRepository<Product>, IProductReadRepository
{
    public ProductReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
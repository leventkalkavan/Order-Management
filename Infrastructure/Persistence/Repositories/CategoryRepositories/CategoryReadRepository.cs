using Application.Repositories.CategoryRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.CategoryRepositories;

public class CategoryReadRepository: ReadRepository<Category>, ICategoryReadRepository
{
    public CategoryReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
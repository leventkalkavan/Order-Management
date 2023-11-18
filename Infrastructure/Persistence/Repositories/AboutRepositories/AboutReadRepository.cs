using Application.Repositories;
using Application.Repositories.AboutRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.AboutRepositories;

public class AboutReadRepository: ReadRepository<About>, IAboutReadRepository
{
    public AboutReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
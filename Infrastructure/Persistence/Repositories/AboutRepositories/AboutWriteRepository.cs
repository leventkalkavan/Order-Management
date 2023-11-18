using Application.Repositories.AboutRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.AboutRepositories;

public class AboutWriteRepository: WriteRepository<About>, IAboutWriteRepository
{
    public AboutWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
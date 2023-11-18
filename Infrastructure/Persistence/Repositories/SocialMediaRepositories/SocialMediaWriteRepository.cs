using Application.Repositories.SocialMediaRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.SocialMediaRepositories;

public class SocialMediaWriteRepository: WriteRepository<SocialMedia>, ISocialMediaWriteRepository
{
    public SocialMediaWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
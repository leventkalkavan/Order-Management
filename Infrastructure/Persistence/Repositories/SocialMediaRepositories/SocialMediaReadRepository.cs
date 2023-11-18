using Application.Repositories.SocialMediaRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.SocialMediaRepositories;

public class SocialMediaReadRepository: ReadRepository<SocialMedia>, ISocialMediaReadRepository
{
    public SocialMediaReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
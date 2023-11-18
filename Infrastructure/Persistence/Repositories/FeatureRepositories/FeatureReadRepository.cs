using Application.Repositories.FeatureRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.FeatureRepositories;

public class FeatureReadRepository: ReadRepository<Feature>, IFeatureReadRepository
{
    public FeatureReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
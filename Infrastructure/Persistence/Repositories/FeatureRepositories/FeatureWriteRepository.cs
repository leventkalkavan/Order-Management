using Application.Repositories.FeatureRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.FeatureRepositories;

public class FeatureWriteRepository: WriteRepository<Feature>, IFeatureWriteRepository
{
    public FeatureWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
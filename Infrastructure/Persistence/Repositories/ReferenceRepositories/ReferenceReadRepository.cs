using Application.Repositories.ReferenceRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.ReferenceRepositories;

public class ReferenceReadRepository: ReadRepository<Reference>, IReferenceReadRepository
{
    public ReferenceReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
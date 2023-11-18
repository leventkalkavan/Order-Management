using Application.Repositories.ReferenceRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.ReferenceRepositories;

public class ReferenceWriteRepository: WriteRepository<Reference>, IReferenceWriteRepository
{
    public ReferenceWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
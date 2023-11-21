using Application.Repositories.VaultRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.VaultRepositories;

public class VaultReadRepository: ReadRepository<Vault>, IVaultReadRepository
{
    public VaultReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
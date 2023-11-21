using Application.Repositories.VaultRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.VaultRepositories;

public class VaultWriteRepository: WriteRepository<Vault>, IVaultWriteRepository
{
    public VaultWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
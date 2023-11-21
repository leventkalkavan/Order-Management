using Application.Repositories.MenuTableRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.MenuTableRepositories;

public class MenuTableWriteRepository: WriteRepository<MenuTable>, IMenuTableWriteRepository
{
    public MenuTableWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
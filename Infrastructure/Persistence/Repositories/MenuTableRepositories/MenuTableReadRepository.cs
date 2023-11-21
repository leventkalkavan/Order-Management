using Application.Repositories.MenuTableRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.MenuTableRepositories;

public class MenuTableReadRepository: ReadRepository<MenuTable>, IMenuTableReadRepository
{
    public MenuTableReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
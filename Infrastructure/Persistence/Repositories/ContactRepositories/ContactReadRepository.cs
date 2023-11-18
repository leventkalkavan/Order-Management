using Application.Repositories.ContactRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.ContactRepositories;

public class ContactReadRepository: ReadRepository<Contact>, IContactReadRepository
{
    public ContactReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
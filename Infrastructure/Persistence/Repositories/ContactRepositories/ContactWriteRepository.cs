using Application.Repositories.ContactRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.ContactRepositories;

public class ContactWriteRepository: WriteRepository<Contact>, IContactWriteRepository
{
    public ContactWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
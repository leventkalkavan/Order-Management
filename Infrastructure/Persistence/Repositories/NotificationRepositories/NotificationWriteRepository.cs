using Application.Repositories.NotificationRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.NotificationRepositories;

public class NotificationWriteRepository: WriteRepository<Notification>, INotificationWriteRepository
{
    public NotificationWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
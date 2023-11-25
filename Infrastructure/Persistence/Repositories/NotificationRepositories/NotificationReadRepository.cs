using Application.Repositories.NotificationRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.NotificationRepositories;

public class NotificationReadRepository: ReadRepository<Notification>, INotificationReadRepository
{
    public NotificationReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}
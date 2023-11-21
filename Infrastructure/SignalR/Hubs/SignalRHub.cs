using Microsoft.AspNetCore.SignalR;
using Persistence.Context;
using Microsoft.Extensions.DependencyInjection;

namespace SignalR.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IServiceProvider _serviceProvider;

        public SignalRHub(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task SendCategoryCount()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var value = dbContext.Categories.Count();

                await Clients.All.SendAsync("ReceiveCategoryCount", value);
            }
        }
    }
}
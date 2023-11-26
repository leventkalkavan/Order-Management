using Application.Repositories.BookingRepositories;
using Application.Repositories.CategoryRepositories;
using Application.Repositories.MenuTableRepositories;
using Application.Repositories.NotificationRepositories;
using Application.Repositories.OrderRepositoires;
using Application.Repositories.ProductRepositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace SignalR.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IMenuTableReadRepository _menuTableReadRepository;
        private readonly IBookingReadRepository _bookingReadRepository;
        private readonly INotificationReadRepository _notificationReadRepository;
        public SignalRHub(ICategoryReadRepository categoryReadRepository, IProductReadRepository productReadRepository, IOrderReadRepository orderReadRepository, IMenuTableReadRepository menuTableReadRepository, IBookingReadRepository bookingReadRepository, INotificationReadRepository notificationReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _productReadRepository = productReadRepository;
            _orderReadRepository = orderReadRepository;
            _menuTableReadRepository = menuTableReadRepository;
            _bookingReadRepository = bookingReadRepository;
            _notificationReadRepository = notificationReadRepository;
        }

        public async Task SendStatistic()
        {
            DateTime today = DateTime.Now.Date;
            var categoryCount = _categoryReadRepository.GetAll().Count();
            var productCount = _productReadRepository.GetAll().Count();
            var passiveCategoryCount = _categoryReadRepository.GetAll().Count(x => x.Status == false);
            var activeCategoryCount = _categoryReadRepository.GetAll().Count(x => x.Status == true);
            var mostExpensiveProduct = _productReadRepository.GetAll().OrderByDescending(x => x.Price).Select(x => x.Name).FirstOrDefault();
            var mostCheapProduct = _productReadRepository.GetAll().OrderBy(x => x.Price).Select(x => x.Name).FirstOrDefault();
            var averageProductPrice = _productReadRepository.GetAll().Average(x => x.Price);
            var orderCount = _orderReadRepository.GetAll().Count();
            var activeOrderCount = _orderReadRepository.GetAll().Count(x => x.Status == true);
            var lastOrderPrice = _orderReadRepository.GetAll().OrderByDescending(x => x.Id).Take(1).Select(x => x.TotalPrice).FirstOrDefault();
            decimal todayTotalPrice = _orderReadRepository.GetAll().Where(x => x.Date.Date == today).Sum(x => x.TotalPrice);
            decimal allTimeTotalPrice = _orderReadRepository.GetAll().Sum(x => x.TotalPrice);
            var menuTableCount = _menuTableReadRepository.GetAll().Count();
            
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);
            await Clients.All.SendAsync("ReceiveProductCount", productCount);
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategoryCount);
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);
            await Clients.All.SendAsync("ReceiveMostExpensiveProduct", mostExpensiveProduct);
            await Clients.All.SendAsync("ReceiveMostCheapProduct", mostCheapProduct);
            await Clients.All.SendAsync("ReceiveAverageProductPrice", averageProductPrice.ToString("0.00")+"₺");
            await Clients.All.SendAsync("ReceiveOrderCount", orderCount);
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderPrice.ToString("0.00")+"₺");
            await Clients.All.SendAsync("ReceiveTodayTotalPrice", todayTotalPrice.ToString("0.00")+"₺");
            await Clients.All.SendAsync("ReceiveAllTimeTotalPrice", allTimeTotalPrice.ToString("0.00")+"₺");
            await Clients.All.SendAsync("ReceiveMenuTableCount", menuTableCount);
        }

        public async Task SendProgress()
        {
            decimal allTimeTotalPrice = _orderReadRepository.GetAll().Sum(x => x.TotalPrice);
            var menuTableCount = _menuTableReadRepository.GetAll().Count();
            var activeOrderCount = _orderReadRepository.GetAll().Count(x => x.Status == true);
            await Clients.All.SendAsync("ReceiveAllTimeTotalPrice", allTimeTotalPrice.ToString("0.00")+"₺");
            await Clients.All.SendAsync("ReceiveMenuTableCount", menuTableCount);
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);
        }

        public async Task GetBookingList()
        {
            var booking = await _bookingReadRepository.GetAll().ToListAsync();
            await Clients.All.SendAsync("ReceiveBookingList",booking);
        }

        public async Task SendNotification()
        {
            var notfFalse = _notificationReadRepository.GetAll().Count(x => x.Status == false);
            var listNotfFalse = _notificationReadRepository.GetAll().Where(x => x.Status == false)
                .ToList();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse",notfFalse);
            await Clients.All.SendAsync("ReceiveFalseNotificationList",listNotfFalse);
        }

        public async Task GetMenuTableStatus()
        {
            var menuTable = await _menuTableReadRepository.GetAll().ToListAsync();
            await Clients.All.SendAsync("ReceiveMenuTableStatus", menuTable);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",user,message);
        }
    }
}
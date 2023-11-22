using Application.Repositories.CategoryRepositories;
using Application.Repositories.MenuTableRepositories;
using Application.Repositories.OrderRepositoires;
using Application.Repositories.ProductRepositories;
using Microsoft.AspNetCore.SignalR;
using Persistence.Context;
using Microsoft.Extensions.DependencyInjection;

namespace SignalR.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IMenuTableReadRepository _menuTableReadRepository;
        public SignalRHub(ICategoryReadRepository categoryReadRepository, IProductReadRepository productReadRepository, IOrderReadRepository orderReadRepository, IMenuTableReadRepository menuTableReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _productReadRepository = productReadRepository;
            _orderReadRepository = orderReadRepository;
            _menuTableReadRepository = menuTableReadRepository;
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
    }
}
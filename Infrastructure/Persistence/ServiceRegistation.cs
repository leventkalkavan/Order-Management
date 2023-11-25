using Application.Repositories.AboutRepositories;
using Application.Repositories.BasketRepositories;
using Application.Repositories.BookingRepositories;
using Application.Repositories.CategoryRepositories;
using Application.Repositories.ContactRepositories;
using Application.Repositories.DiscountRepositories;
using Application.Repositories.FeatureRepositories;
using Application.Repositories.MenuTableRepositories;
using Application.Repositories.NotificationRepositories;
using Application.Repositories.OrderDetailRepositoires;
using Application.Repositories.OrderRepositoires;
using Application.Repositories.ProductRepositories;
using Application.Repositories.ReferenceRepositories;
using Application.Repositories.SliderRepositories;
using Application.Repositories.SocialMediaRepositories;
using Application.Repositories.VaultRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories.AboutRepositories;
using Persistence.Repositories.BasketRepositories;
using Persistence.Repositories.BookingRepositories;
using Persistence.Repositories.CategoryRepositories;
using Persistence.Repositories.ContactRepositories;
using Persistence.Repositories.DiscountRepositories;
using Persistence.Repositories.FeatureRepositories;
using Persistence.Repositories.MenuTableRepositories;
using Persistence.Repositories.NotificationRepositories;
using Persistence.Repositories.OrderDetailRepositoires;
using Persistence.Repositories.OrderRepositories;
using Persistence.Repositories.ProductRepositories;
using Persistence.Repositories.ReferenceRepositories;
using Persistence.Repositories.SliderRepositories;
using Persistence.Repositories.SocialMediaRepositories;
using Persistence.Repositories.VaultRepositories;

namespace Persistence;

public static class ServiceRegistation
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString));

        services.AddScoped<IAboutReadRepository, AboutReadRepository>();
        services.AddScoped<IAboutWriteRepository, AboutWriteRepository>();
        
        services.AddScoped<IBookingReadRepository, BookingReadRepository>();
        services.AddScoped<IBookingWriteRepository, BookingWriteRepository>();
        
        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
        
        services.AddScoped<IContactReadRepository, ContactReadRepository>();
        services.AddScoped<IContactWriteRepository, ContactWriteRepository>();
        
        services.AddScoped<IDiscountReadRepository, DiscountReadRepository>();
        services.AddScoped<IDiscountWriteRepository, DiscountWriteRepository>();
        
        services.AddScoped<IFeatureReadRepository, FeatureReadRepository>();
        services.AddScoped<IFeatureWriteRepository, FeatureWriteRepository>();
        
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        
        services.AddScoped<IReferenceReadRepository, ReferenceReadRepository>();
        services.AddScoped<IReferenceWriteRepository, ReferenceWriteRepository>();
        
        services.AddScoped<ISocialMediaReadRepository, SocialMediaReadRepository>();
        services.AddScoped<ISocialMediaWriteRepository, SocialMediaWriteRepository>();
        
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        
        services.AddScoped<IOrderDetailReadRepositoires, OrderDetailReadRepository>();
        services.AddScoped<IOrderDetailWriteRepositoires, OrderDetaiWriteRepository>();
        
        services.AddScoped<IVaultReadRepository, VaultReadRepository>();
        services.AddScoped<IVaultWriteRepository, VaultWriteRepository>();
        
        services.AddScoped<IMenuTableReadRepository, MenuTableReadRepository>();
        services.AddScoped<IMenuTableWriteRepository, MenuTableWriteRepository>();
        
        services.AddScoped<ISliderReadRepository, SliderReadRepository>();
        services.AddScoped<ISliderWriteRepository, SliderWriteRepository>();
        
        services.AddScoped<IBasketReadRepository, BasketReadRepository>();
        services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
        
        services.AddScoped<INotificationReadRepository, NotificationReadRepository>();
        services.AddScoped<INotificationWriteRepository, NotificationWriteRepository>();
    }
}
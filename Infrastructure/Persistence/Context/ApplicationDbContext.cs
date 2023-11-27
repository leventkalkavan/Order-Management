using Domain;
using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class ApplicationDbContext:IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions options):base(options)
    {}
    public DbSet<About> Abouts { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Reference> References { get; set; }
    public DbSet<SocialMedia> SocialMedia { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Vault> Vaults { get; set; }
    public DbSet<MenuTable> MenuTables { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Basket>()
            .HasOne(b => b.Product)
            .WithMany()
            .HasForeignKey(b => b.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Basket>()
            .HasOne(b => b.MenuTable)
            .WithMany()
            .HasForeignKey(b => b.MenuTableId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }

}
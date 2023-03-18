using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using Shop.Domain;
using Shop.Persistence.EntityTypeConfigurations;

namespace Shop.Persistence;

public class ShopDbContext 
    : DbContext, IShopDbContext 
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Order> Orders { get; set; }

    public ShopDbContext(DbContextOptions<ShopDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
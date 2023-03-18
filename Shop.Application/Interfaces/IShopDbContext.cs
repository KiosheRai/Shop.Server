using Microsoft.EntityFrameworkCore;
using Shop.Domain;

namespace Shop.Application.Interfaces;

public interface IShopDbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Order> Orders { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

using Shop.Domain;

namespace Shop.Application.Interfaces;

public interface IUnitOfWork
    : IDisposable
{
    public IRepository<Book> Books { get; }
    public IRepository<Order> Orders { get; }

    public Task<int> SaveChangesAsync();
}

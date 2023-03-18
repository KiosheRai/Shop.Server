using Shop.Application.Interfaces;
using Shop.Domain;
using Shop.Persistence.Repositories;

namespace Shop.Persistence;

public class UnitOfWork
    : IUnitOfWork
{
    private readonly ShopDbContext _context;

    public IRepository<Book> Books { get; private set; }
    public IRepository<Order> Orders { get; private set; }

    public UnitOfWork(ShopDbContext context)
    {
        _context = context;
        Books = new BookRepository(_context);
        Orders = new OrderRepository(_context);
    }

    public async Task<int> SaveChangesAsync() =>
        await _context.SaveChangesAsync();

    public void Dispose() => 
        _context.Dispose();
    
}
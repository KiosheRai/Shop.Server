using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using Shop.Domain;
using System.Linq.Expressions;

namespace Shop.Persistence.Repositories;

public class OrderRepository
    : IRepository<Order>
{
    private readonly ShopDbContext _context;

    public OrderRepository(ShopDbContext context) =>
        _context = context;

    public async Task CreateAsync(Order entity) =>
        await _context.Orders.AddAsync(entity);

    public async Task<Order?> FirstOrDefaultAsync(Expression<Func<Order, bool>> predicate) =>
         await _context.Orders.Include(x => x.Books).FirstOrDefaultAsync(predicate);

    public async Task<IEnumerable<Order>> GetAllAsync() =>
         await _context.Orders.ToListAsync();

    public async Task<IEnumerable<Order>?> GetFiltered(Expression<Func<Order, bool>> predicate) =>
         await _context.Orders.Include(x => x.Books).Where(predicate).ToListAsync();

    public async Task<IEnumerable<Order>?> GetRange(Expression<Func<Order, bool>> predicate) =>
       await _context.Orders.Where(predicate).ToListAsync();

    public void Remove(Order entity) =>
        _context.Orders.Remove(entity);
}
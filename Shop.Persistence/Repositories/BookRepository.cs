using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using Shop.Domain;
using System.Linq.Expressions;

namespace Shop.Persistence.Repositories;

public class BookRepository
    : IRepository<Book>
{
    private readonly ShopDbContext _context;

    public BookRepository(ShopDbContext context) =>
        _context = context;

    public async Task CreateAsync(Book entity) =>
        await _context.Books.AddAsync(entity);

    public async Task<Book?> FirstOrDefaultAsync(Expression<Func<Book, bool>> predicate) =>
         await _context.Books.FirstOrDefaultAsync(predicate);

    public async Task<IEnumerable<Book>> GetAllAsync() =>
         await _context.Books.ToListAsync();

    public async Task<IEnumerable<Book>?> GetFiltered(Expression<Func<Book, bool>> predicate) =>
         await _context.Books.Where(predicate).ToListAsync();

    public async Task<IEnumerable<Book>?> GetRange(Expression<Func<Book, bool>> predicate) =>
        await _context.Books.Where(predicate).ToListAsync();

    public void Remove(Book entity) =>
        _context.Books.Remove(entity);
}
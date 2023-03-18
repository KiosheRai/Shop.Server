using System.Linq.Expressions;

namespace Shop.Application.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    public Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    public Task<IEnumerable<TEntity>?> GetRange(Expression<Func<TEntity, bool>> predicate);
    public Task<IEnumerable<TEntity>?> GetFiltered(Expression<Func<TEntity, bool>> predicate);
    public Task<IEnumerable<TEntity>> GetAllAsync();

    public Task CreateAsync(TEntity entity);
    public void Remove(TEntity entity);
}


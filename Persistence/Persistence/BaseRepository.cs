using System.Linq.Expressions;
using Application.Contracts.Persistence;
using Persistence.DatabaseConfig;

namespace Persistence.Persistence;

public class BaseRepository<T> : IAsyncRepository<T> where T : class
{
    protected readonly ApplicationDbContext DbContext;

    protected BaseRepository(ApplicationDbContext dbContext) => DbContext = dbContext;
    
    public Task<List<T>> ListAllAsync() => DbContext.Set<T>().ToListAsync();

    public async Task<T> AddAsync(T entity)
    {
        await DbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public void AddOrUpdateRange(ICollection<T> entity) => DbContext.Set<T>().UpdateRange(entity);

    public void Update(T entity) => DbContext.Set<T>().Update(entity);

    public void Delete(T entity) => DbContext.Set<T>().Remove(entity);
    
    public Task<T?> GetAsync(int id) => DbContext.Set<T>().FindAsync(id).AsTask();
}

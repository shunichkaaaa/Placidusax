using Microsoft.EntityFrameworkCore;
using Placidusax.Data;
using Placidusax.Interfaces;

namespace Placidusax.Implementations;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly PlacidusaxDbContext _dataContext;

    public Repository(PlacidusaxDbContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dataContext.AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        await _dataContext.AddRangeAsync(entities);
        return entities;
    }

    public void Update(T entity)
    {
        ThrowIfEntityIsNull(entity);
        _dataContext.Update(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dataContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetAsync(string id)
    {
        return await _dataContext.Set<T>().FindAsync(id);
    }

    public async Task SaveChangesAsync()
    {
        await _dataContext.SaveChangesAsync();
    }

    public void Remove(T entity)
    {
        ThrowIfEntityIsNull(entity);
        _dataContext.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dataContext.Set<T>().RemoveRange(entities);
    }

    private void ThrowIfEntityIsNull(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
    }
}
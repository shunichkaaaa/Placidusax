namespace Placidusax.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetAsync(string id);

    Task<IEnumerable<T>> GetAllAsync();

    Task<T> AddAsync(T entity);

    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);

    Task SaveChangesAsync();

    void Remove(T entity);

    void RemoveRange(IEnumerable<T> entities);
}

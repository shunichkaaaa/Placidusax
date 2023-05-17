using Placidusax.Data;
using Placidusax.Interfaces;

namespace Placidusax.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly IServiceProvider _serviceProvider;
    private readonly PlacidusaxDbContext _context;
    private Dictionary<Type, object> _repositories;

    public UnitOfWork(IServiceProvider serviceProvider, PlacidusaxDbContext context)
    {
        _serviceProvider = serviceProvider;
        _context = context;
        _repositories = new Dictionary<Type, object>();
    }

    public IRepository<T> Repository<T>() where T : class
    {
        if (_repositories.ContainsKey(typeof(T)))
            return _repositories[typeof(T)] as IRepository<T>;

        IRepository<T> repo = _serviceProvider.GetRequiredService<IRepository<T>>();
        _repositories.Add(typeof(T), repo);

        return repo;
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    private bool disposedValue = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            disposedValue = true;
        }
    }

    ~UnitOfWork()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

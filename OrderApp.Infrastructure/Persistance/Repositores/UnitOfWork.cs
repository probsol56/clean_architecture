using OrderApp.Application.Common.Interfaces;
using OrderApp.Infrastructure.Persistance;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IProductRepository Products => new ProductRepository(_context);
    public ICategoryRepository Categories => new CategoryRepository(_context);
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
    public void Dispose() => _context.Dispose();
}
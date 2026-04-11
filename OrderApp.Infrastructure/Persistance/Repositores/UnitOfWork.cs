using OrderApp.Application.Common.Interfaces;
using OrderApp.Infrastructure.Persistance;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IProductRepository Products { get; }
    public ICategoryRepository Categories { get; }

    public UnitOfWork(AppDbContext context, IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _context = context;
        Products = productRepository;
        Categories = categoryRepository;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
    public void Dispose() => _context.Dispose();
}
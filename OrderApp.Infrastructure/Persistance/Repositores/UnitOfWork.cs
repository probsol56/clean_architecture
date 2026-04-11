using OrderApp.Application.Common.Interfaces;
using OrderApp.Infrastructure.Persistance;
namespace OrderApp.Infrastructure.Persistance.Repositores;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IProductRepository Products { get; }
    public ICategoryRepository Categories { get; }
    public IOrderRepository Orders { get; }

    public UnitOfWork(AppDbContext context, IProductRepository productRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository)
    {
        _context = context;
        Products = productRepository;
        Categories = categoryRepository;
        Orders = orderRepository;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
    public void Dispose() => _context.Dispose();
}
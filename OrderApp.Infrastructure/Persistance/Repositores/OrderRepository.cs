using OrderApp.Application.Common.Interfaces;
using OrderApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace OrderApp.Infrastructure.Persistance.Repositores;

public class OrderRepository(AppDbContext _context) : IOrderRepository
{
    public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task AddAsync(Order order, CancellationToken cancellationToken)
    {
        await _context.Orders.AddAsync(order, cancellationToken);
    }
}
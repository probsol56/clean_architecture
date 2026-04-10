using OrderApp.Domain.Entities;

namespace OrderApp.Application.Common.Interfaces;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(Guid id,CancellationToken ct = default);
    Task AddAsync(Order order,CancellationToken ct = default);
}
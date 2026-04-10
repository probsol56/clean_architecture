using OrderApp.Domain.Entities;

namespace OrderApp.Application.Common.Interfaces;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(int id);
    Task AddAsync(Order order);
}
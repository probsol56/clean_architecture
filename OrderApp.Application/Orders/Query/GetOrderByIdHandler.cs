using MediatR;
using OrderApp.Application.Common.Exceptions;
using OrderApp.Application.Common.Interfaces;
using OrderApp.Application.DTOs;

namespace OrderApp.Application.Orders.Query;

public class GetOrderByIdHandler(IOrderRepository orderRepository) : IRequestHandler<GetOrderById, OrderDto?>
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<OrderDto?> Handle(GetOrderById request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);
        return order == null
            ? throw new NotFoundException($"Order {request.Id} not found")
            : new OrderDto(order.Id, order.CustomerId, order.TotalAmount.Amount, order.Status.ToString());
    }
}
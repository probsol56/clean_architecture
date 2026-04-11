using MediatR;
using OrderApp.Application.Common.Exceptions;
using OrderApp.Application.Common.Interfaces;
using OrderApp.Application.DTOs;

namespace OrderApp.Application.Orders.Query;

public class GetOrderByIdHandler : IRequestHandler<GetOrderById, OrderDto?>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderDto?> Handle(GetOrderById request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);
        if (order == null)
        {
            throw new NotFoundException($"Order {request.Id} not found");
        }

        return new OrderDto(order.Id, order.CustomerId, order.TotalAmount.Amount, order.Status.ToString());
    }
}
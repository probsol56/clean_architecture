

using MediatR;

namespace OrderApp.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(
    Guid CustomerId,
    List<OrderItemDto> Items
) : IRequest<Guid>;

public record OrderItemDto(
    Guid ProductId,
    int Quantity,
    decimal UnitPrice
);
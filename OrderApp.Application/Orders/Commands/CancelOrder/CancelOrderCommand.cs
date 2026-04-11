using MediatR;

namespace OrderApp.Application.Orders.Commands.CancelOrder;

public record CancelOrderCommand(Guid Id) : IRequest<Unit>;
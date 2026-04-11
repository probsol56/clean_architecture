using MediatR;
using OrderApp.Application.DTOs;

namespace OrderApp.Application.Orders.Query;

public record GetOrderById(Guid Id) : IRequest<OrderDto?>;
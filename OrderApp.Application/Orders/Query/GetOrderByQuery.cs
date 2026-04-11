using MediatR;
using OrderApp.Application.DTOs;

namespace OrderApp.Application.Orders.Query;

public record GetOrderByQuery(Guid Id) : IRequest<OrderDto?>;
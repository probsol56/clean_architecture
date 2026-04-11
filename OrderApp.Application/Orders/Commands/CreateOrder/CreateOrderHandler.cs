using MediatR;
using OrderApp.Application.Common.Interfaces;
using OrderApp.Domain.Entities;

namespace OrderApp.Application.Orders.Commands.CreateOrder;

public class CreateOrderHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<CreateOrderCommand, Guid>  
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Guid> Handle(  // HandleAsync না, Handle হবে
        CreateOrderCommand request,
        CancellationToken cancellationToken)
    { 

        var orderItems = request.Items.Select(x => new OrderItem(x.ProductId, x.Quantity, x.UnitPrice)).ToList();
        var order = Order.Create(request.CustomerId, orderItems);
        await _orderRepository.AddAsync(order, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return order.Id;
     }
}

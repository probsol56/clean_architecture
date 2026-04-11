using OrderApp.Application.Common.Interfaces;

namespace OrderApp.Application.Orders.Commands.CreateOrder;

public class CreateOrderHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
{
    public async Task<Guid> HandleAsync(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

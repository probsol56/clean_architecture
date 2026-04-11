using MediatR;
using OrderApp.Application.Common.Exceptions;
using OrderApp.Application.Common.Interfaces;

namespace OrderApp.Application.Orders.Commands.CancelOrder;

public class CancelOrderHandler : IRequestHandler<CancelOrderCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CancelOrderHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id,cancellationToken) ?? throw new NotFoundException("Order not found");
        order.Cancel();
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
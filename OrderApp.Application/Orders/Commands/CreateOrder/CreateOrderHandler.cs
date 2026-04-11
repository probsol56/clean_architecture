using MediatR;
using OrderApp.Application.Common.Interfaces;

namespace OrderApp.Application.Orders.Commands.CreateOrder;

public class CreateOrderHandler
    : IRequestHandler<CreateOrderCommand, Guid>  
{
    public  Task<Guid> Handle(  // HandleAsync না, Handle হবে
        CreateOrderCommand request,
        CancellationToken cancellationToken)
    { 
        throw new NotImplementedException();
     }
}

using OrderApp.Domain.Entities.Enums;
using OrderApp.Domain.ValueObjects;

namespace OrderApp.Domain.Entities;

public class Order(Guid customerId)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid CustomerId { get; private set; } = customerId;   
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;
    public List<OrderItem> Items { get; private set; } = new();
    public Money TotalAmount { get; private set; } = new(0, "USD");
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public void Confirm()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Only pending orders can be confirmed.");
        Status = OrderStatus.Confirmed;
    }
}
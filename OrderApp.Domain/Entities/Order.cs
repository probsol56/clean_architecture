using OrderApp.Domain.Entities.Enums;
using OrderApp.Domain.ValueObjects;

namespace OrderApp.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; private set; }
    public OrderStatus Status { get; private set; }
    public List<OrderItem> Items { get; private set; } = new();
    public Money TotalAmount { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public void Confirm()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Cannot confirm a cancelled order.");
        Status = OrderStatus.Confirmed;
    }
}
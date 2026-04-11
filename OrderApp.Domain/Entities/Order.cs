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

    public static Order Create(Guid customerId, List<OrderItem> items)
    {
        if (customerId == Guid.Empty)
            throw new Exception("Customer ID cannot be empty");

        if (items.Count == 0)
            throw new Exception("Order must have at least one item");
        var order = new Order(customerId);
        order.Items.AddRange(items);
        order.TotalAmount = new Money(items.Sum(x => x.Quantity * x.UnitPrice), "USD");
        return order;
    }

    public void Confirm()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Only pending orders can be confirmed.");
        Status = OrderStatus.Confirmed;
    }

    public void Cancel()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Only pending orders can be cancelled.");
        Status = OrderStatus.Cancelled;
    }
}
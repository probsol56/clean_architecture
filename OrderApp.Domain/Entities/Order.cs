using OrderApp.Domain.Entities.Enums;

namespace OrderApp.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public string CustomerId { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderItem> Items { get; set; } = new();
    public decimal TotalAmount { get; set; }

    public void Confirm()
    {
        if (Status == OrderStatus.Cancelled)
            throw new InvalidOperationException("Cannot confirm a cancelled order.");
        Status = OrderStatus.Confirmed;
    }
}
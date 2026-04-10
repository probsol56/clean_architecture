namespace OrderApp.Domain.Entities;

public record OrderItem
{
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; private set; }
}
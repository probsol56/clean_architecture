namespace OrderApp.Domain.Entities;

public record OrderItem(Guid ProductId, int Quantity, decimal UnitPrice);
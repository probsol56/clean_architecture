namespace OrderApp.Application.DTOs;

public record OrderDto(Guid Id, Guid CustomerId, decimal TotalAmount, string Status);
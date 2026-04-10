namespace OrderApp.Domain.ValueObjects;

public record Money(decimal Amount, string Currency)
{
    // Value Object — দুটো Money equal যদি Amount ও Currency equal হয়
    public static Money operator +(Money a, Money b)
    {
        if (a.Currency != b.Currency)
            throw new InvalidOperationException("Cannot add different currencies.");
        return new Money(a.Amount + b.Amount, a.Currency);
    }
}


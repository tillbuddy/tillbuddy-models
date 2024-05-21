
namespace TillBuddy.Models;

public interface ICash : ICloneable
{
    public string UserId { get; set; }
    public Money Amount { get; set; }
    public DateTime RegisteredAt { get; set; }
}

public class Cash : ValueObject, ICash
{
    public string UserId { get; set; } = null!;
    public Money Amount { get; set; } = null!;
    public DateTime RegisteredAt { get; set; }

    public Cash() { }

    public Cash(
       string userId,
       string amount,
       DateTime registeredAt)
    {
        if (string.IsNullOrEmpty(userId)) throw new ArgumentNullException(nameof(userId));
        if (string.IsNullOrEmpty(amount)) throw new ArgumentNullException(nameof(amount));

        UserId = userId;
        Amount = Money.Parse(amount);
        RegisteredAt = registeredAt;
    }

    public Cash(
        Guid userId,
        Money amount,
        DateTime registeredAt)
    {
        if (userId == Guid.Empty) throw new ArgumentNullException(nameof(userId));
        if (amount is null) throw new ArgumentNullException(nameof(amount));

        UserId = userId.ToString();        
        Amount = amount;
        RegisteredAt = registeredAt;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return UserId;
        yield return Amount.Amount;
        yield return Amount.Currency;
        yield return RegisteredAt;
    }

    public Cash Parse(ICash source)
    {
        return new()
        {
            UserId = source.UserId,
            Amount = source.Amount,
            RegisteredAt = source.RegisteredAt
        };
    }

    private T Apply<T>(T target) where T : ICash
    {
        target.UserId = UserId;
        target.Amount = (Money)Amount.Clone();
        target.RegisteredAt = RegisteredAt;

        return target;
    }

    public CashResponse MapToResponse()
    {
        return Apply(new CashResponse());
    }

    public CashRequest MapToRequest()
    {
        return Apply(new CashRequest());
    }

    public object Clone()
    {
        return new Cash
        {
            Amount = Amount,
            RegisteredAt = RegisteredAt,
            UserId = UserId
        };
    }
}

public class CashRequest : Cash
{
}

public class CashResponse : Cash
{
}
using Dawn;

namespace TillBuddy.SDK.Model;

/// <summary>
/// Money registred by one person at a specific time
/// </summary>
public sealed class Cash : IEquatable<Cash>
{
    public Guid UserId { get; set; }
    public Money Amount { get; set; }
    public DateTime RegisteredAt { get; set; }

    public Cash() 
    {
        UserId = Guid.Empty;
        Amount = new Money();
        RegisteredAt = DateTime.MinValue;
    }

    public Cash(Guid userId,
                Money amount,
                DateTime registeredAt)
    {
        Guard.Argument(() => userId).NotDefault();
        Guard.Argument(() => amount).NotNull();
        Guard.Argument(() => registeredAt).NotDefault();

        UserId = userId;
        Amount = amount;
        RegisteredAt = registeredAt;
    }

    public static Cash Parse(CashRequest source)
    {
        Guard.Argument(() => source).NotNull();
        Guard.Argument(() => source.UserId).NotEqual(Guid.Empty);

        return new Cash
            (
                source.UserId,
                Money.Parse(source.Amount),
                source.RegisteredAt
            );
    }

    public CashResponse ToResponse()
    {
        return new CashResponse
        {
            UserId = UserId,
            Amount = Amount.ToString(),
            RegisteredAt = RegisteredAt
        };
    }

    public bool Equals(Cash? other)
    {
        if (UserId != other?.UserId) return false;

        if (Amount != other.Amount) return false;

        if (RegisteredAt != other.RegisteredAt) return false;

        return true;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Cash);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(UserId, Amount, RegisteredAt);
    }
}

public class CashRequest
{
    public Guid UserId { get; set; }
    /// <summary>
    /// Amount in format "amount currency"
    /// 
    /// Example) "100.00 NOK"
    /// </summary>
    public string Amount { get; set; } = null!;
    /// <summary>
    /// UTC time when the cash was registered
    /// </summary>
    public DateTime RegisteredAt { get; set; }
}

public class CashResponse
{
    public Guid UserId { get; set; }
    /// <summary>
    /// Amount in format "amount currency"
    /// 
    /// Example) "100.00 NOK"
    /// </summary>
    public string Amount { get; set; } = null!;
    /// <summary>
    /// UTC time when the cash was registered
    /// </summary>
    public DateTime RegisteredAt { get; set; }
}

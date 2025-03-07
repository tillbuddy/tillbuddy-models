﻿using Ardalis.GuardClauses;

namespace TillBuddy.Models;

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
        Guard.Against.Default(userId, nameof(userId));
        Guard.Against.Null(amount, nameof(amount));
        Guard.Against.Default(registeredAt, nameof(registeredAt));

        UserId = userId;
        Amount = amount;
        RegisteredAt = registeredAt;
    }

    public static Cash Parse(CashRequest source)
    {
        Guard.Against.Null(source, nameof(source));
        Guard.Against.Default(source.UserId, nameof(source.UserId));

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

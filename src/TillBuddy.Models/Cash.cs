
namespace TillBuddy.Models;

public interface ICash
{
    public string UserId { get; set; }
    public IMoney Amount { get; set; }
    public DateTime RegisteredAt { get; set; }

}

public class Cash : ValueObject, ICash
{
    public string UserId { get; set; } = null!;
    public IMoney Amount { get; set; } = null!;
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
        IMoney amount,
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
}

public class CashRequest : Cash
{
}

public class CashRsponse : Cash
{
}
namespace TillBuddy.Models;

public interface IDiscountOrMoney
{
    public IMoney? Money { get; set; }

    public decimal? Percent { get; set; }

    public string? Intention { get; set; }

    public decimal? Amount { get; set; }

    public string? Currency { get; set; }
}

public class DiscountOrMoney : IDiscountOrMoney
{
    public IMoney? Money { get; set; }

    public decimal? Percent { get; set; }

    public string? Intention { get; set; }

    public decimal? Amount { get; set; }

    public string? Currency { get; set; }

    public DiscountOrMoney()
    {

    }

    public DiscountOrMoney(
        IMoney? money,
        decimal? percent,
        string? intention,
        decimal? amount,
        string? currency)
    {
        Money = money;
        Percent = percent;
        Intention = intention;
        Amount = amount;
        Currency = currency;
    }

    public decimal? GetAmount()
    {
        // old version
        if (Amount != null)
            return Amount;

        // new version
        if (Money != null)
            return Money.Amount;

        return null;
    }

    public IMoney? GetMoney()
    {
        // old version
        if (Amount != null && Currency != null)
            return new Money(Amount.Value, Currency);

        // new version
        if (Money != null)
            return Money;

        return null;
    }
}

public class DiscountOrMoneyRequest : DiscountOrMoney
{
    public DiscountOrMoneyRequest() : base() { }

    public DiscountOrMoneyRequest(IMoney? money, decimal? percent, string? intention, decimal? amount, string? currency) : base(money, percent, intention, amount, currency) { }
}

public class DiscountOrMoneyResponse : DiscountOrMoney
{
    public DiscountOrMoneyResponse() : base() { }

    public DiscountOrMoneyResponse(IMoney? money, decimal? percent, string? intention, decimal? amount, string? currency) : base(money, percent, intention, amount, currency) { }
}

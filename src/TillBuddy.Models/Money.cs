using System.Globalization;
using System.Text.RegularExpressions;

namespace TillBuddy.Models;

public interface IMoney
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }
}

public class Money : IMoney
{
    private const string RegexPattern = "((?<amount>.+) (?<currency>.+)$)";
    private static readonly Regex Regex = new Regex(RegexPattern);

    public decimal Amount { get; set; }
    public string Currency { get; set; } = null!;

    public Money() { }

    public Money(string money)
    {
        ParseToSelf(money);
    }

    public Money Parse(IMoney money)
    {
        return new Money(money.Amount, money.Currency);
    }

    private void ParseToSelf(string value)
    {
        // Validate expression with regex
        var matches = Regex.Matches(value);
        if (matches.Count != 1)
            throw new ArgumentException(nameof(Money), $"\"{RegexPattern}\"");

        var amountValue = matches[0].Groups["amount"].Value;
        var currencyValue = matches[0].Groups["currency"].Value;

        ParseAmountToSelf(amountValue);
        ParseCurrencyToSelf(currencyValue);
    }

    private void ParseCurrencyToSelf(string currencyValue)
    {
        var currency = Models.Currency.Parse(currencyValue);

        Currency = currency;
    }

    private void ParseAmountToSelf(string amountValue)
    {
        if (!decimal.TryParse(amountValue, NumberStyles.Number, CultureInfo.InvariantCulture, out var amount))
            throw new ArgumentException("Money.Amount", "decimal \"NumberStyles.Number\"");

        Amount = amount;
    }

    public Money(decimal amount, Currency currency)
    {
        if(currency == null) throw new ArgumentNullException(nameof(currency));

        Amount = amount;
        Currency = currency;
    }

    public Money(decimal amount, string currency)
    {
        if (string.IsNullOrEmpty(currency)) throw new ArgumentException("Currency can't be empty", nameof(currency));

        Currency = Models.Currency.Parse(currency);
        Amount = amount;
    }

    public static Money Parse(string value)
    {
        if (TryParse(value, out var money))
            return money;
        throw new Exception($"Invalid format: \"{RegexPattern}\"");
    }

    public static bool TryParse(string value, out Money money)
    {
        money = new Money();

        if (value == null) return false;

        try
        {
            money = new Money(value);
            return true;
        }
        catch
        {
            return false;
        }
    }


    public static implicit operator string(Money money)
    {
        return money.ToString();
    }

    public override string ToString()
    {
        return $"{Amount.ToString("F2", CultureInfo.InvariantCulture)} {Currency}";
    }

    public bool HasSameCurrency(Money money)
    {
        return money.Currency.Equals(Currency);
    }

    public Money Add(Money money)
    {
        if (!HasSameCurrency(money))
            throw new Exception($"Money has different currency. Current: {Currency}. Compared: {money.Currency}");

        Amount += money.Amount;

        return this;
    }

    public Money AddRange(IEnumerable<Money> moneys)
    {
        foreach (var money in moneys)
        {
            Add(money);
        }

        return this;
    }
}

public class MoneyRequest : Money
{
}

public class MoneyResponse : Money
{
}


public static class MoneyMapper
{
    public static MoneyResponse MapToResponse(this IMoney source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        return new()
        {
            Amount = source.Amount,
            Currency = source.Currency,
        };
    }

    public static MoneyRequest MapToRequest(this IMoney source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        return new()
        {
            Amount = source.Amount,
            Currency = source.Currency,
        };
    }

    public static string MapToString(this IMoney source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        return new Money(source.Amount, source.Currency).ToString();
    }
}

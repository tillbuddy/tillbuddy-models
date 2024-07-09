using Dawn;
using System.Globalization;
using System.Text.RegularExpressions;
using TillBuddy.Models.Exceptions;

namespace TillBuddy.Models;

public sealed class Money : IEquatable<Money>
{
    private const string RegexPattern = "((?<amount>.+) (?<currency>.+)$)";
    private static readonly Regex Regex = new Regex(RegexPattern);
    public decimal Amount { get; set; }
    public Currency Currency { get; set; } = null!;

    /// <summary>
    /// Default constructor for Money, sets Amount to 0 and Currency to NOK
    /// </summary>
    public Money()
    {
        Amount = 0;
        Currency = Currency.Parse("NOK");
    }

    public Money(string money)
    {
        Amount = 0;

        ParseToSelf(money);
    }

    public Money(decimal amount, Currency currency)
    {
        Guard.Argument(() => currency).NotNull();

        Amount = amount;
        Currency = currency;
    }

    public Money(decimal amount, string currency)
    {
        Guard.Argument(() => currency).NotNull();

        Currency = Currency.Parse(currency);
        Amount = amount;
    }


    private void ParseToSelf(string value)
    {
        // Validate expression with regex
        var matches = Regex.Matches(value);
        if (matches.Count != 1)
            throw new MoneyArgumentFormatException(nameof(Money), $"\"{RegexPattern}\"", value);

        var amountValue = matches[0].Groups["amount"].Value;
        var currencyValue = matches[0].Groups["currency"].Value;

        ParseAmountToSelf(amountValue);
        ParseCurrencyToSelf(currencyValue);
    }

    private void ParseCurrencyToSelf(string currencyValue)
    {
        var currency = Currency.Parse(currencyValue);

        Currency = currency;
    }

    private void ParseAmountToSelf(string amountValue)
    {
        if (!decimal.TryParse(amountValue, NumberStyles.Number, CultureInfo.InvariantCulture, out var amount))
            throw new MoneyArgumentFormatException("Money.Amount", "decimal \"NumberStyles.Number\"", amountValue);

        Amount = amount;
    }

    public static Money Parse(MoneyRequest money)
    {
        return new Money(money.Amount, money.Currency);
    }


    public static Money Parse(MoneyResponse money)
    {
        return new Money(money.Amount, money.Currency);
    }


    public static Money Parse(string value)
    {
        if (TryParse(value, out var money))
            return money;
        throw new MoneyArgumentFormatException(nameof(Money), $"\"{RegexPattern}\"", value);
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

    public static implicit operator string(Money? money)
    {
        return money?.ToString() ?? string.Empty;
    }

    public MoneyResponse ToResponse()
    {
        return new()
        {
            Amount = Amount,
            Currency = Currency.ToString()
        };
    }

    public MoneyRequest ToRequest()
    {
        return new()
        {
            Amount = Amount,
            Currency = Currency.ToString()
        };
    }

    /// <summary>
    /// Return the string representation of the Money object in the format "amount currency" where amount is formatted with two decimal places amd invariant culture
    /// 
    /// Example: "100.00 NOK"
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{Amount.ToString("F2", CultureInfo.InvariantCulture)} {Currency}";
    }

    public bool HasSameCurrency(Money money)
    {
        return money.Currency.Equals(Currency);
    }

    // Add money to the current money object.
    //
    // If the currency is different, throw an exception
    public Money Add(Money money)
    {
        if (!HasSameCurrency(money))
            throw new CurrencyMismatchException(Currency, money.Currency);

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

    public bool Equals(Money? other)
    {
        if(other == null) return false; 

        if (string.Compare(Currency, other.Currency) != 0) return false;

        if (Amount != other.Amount) return false;

        return true;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Money);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Currency, Amount);
    }
}

public class MoneyRequest
{
    public decimal Amount { get; set; }
    public string Currency { get; set; } = null!;
}


public class MoneyResponse
{
    public decimal Amount { get; set; }
    public string Currency { get; set; } = null!;
}




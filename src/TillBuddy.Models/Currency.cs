using System.Text.RegularExpressions;

namespace TillBuddy.Models;

public class Currency : ValueObject
{
    private const string RegexPattern = "^[a-zA-Z]{3}$";
    private static readonly Regex Regex = new Regex(RegexPattern);

    public string Value { get; set; }

    public Currency() 
    { 
        Value = string.Empty;
    }

    public Currency(string value)
    {
        Value = value.ToUpperInvariant();
    }

    public static implicit operator string(Currency currency)
    {
        return currency.ToString();
    }

    public static implicit operator Currency(string money)
    {
        return Parse(money);
    }

    public static Currency Parse(string value)
    {
        if (TryParse(value, out var currency)) return currency;

        throw new ArgumentException($"ISO-4217 \"{RegexPattern}\"", nameof(value));
    }

    public static bool TryParse(string value, out Currency currency)
    {
        currency = new Currency();

        if (value == null) return false;

        var matches = Regex.Matches(value);

        if (matches.Count == 1)
        {
            currency = new Currency(value);
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return Value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

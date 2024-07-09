using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using TillBuddy.Models.Converters;
using TillBuddy.SDK.Model.Exceptions;

namespace TillBuddy.SDK.Model;

/// <summary>
/// https://en.wikipedia.org/wiki/ISO_4217
/// </summary>
[JsonConverter(typeof(JsonCurrencyConverter))]
public sealed class Currency : IEquatable<Currency>
{
    private const string RegexPattern = "^[a-zA-Z]{3}$";
    private static readonly Regex Regex = new Regex(RegexPattern);

    public string Value { get; set; }

    /// <summary>
    /// Default constructor for Currency, sets Currency to NOK
    /// </summary>
    public Currency()
    {
        Value = "NOK";
    }

    public Currency(string value)
    {
        Value = value.ToUpperInvariant();
    }

    public static implicit operator string(Currency? currency)
    {
        return currency?.ToString() ?? string.Empty;
    }

    public static implicit operator Currency(string money)
    {
        return Parse(money);
    }

    public static Currency Parse(string value)
    {
        if (TryParse(value, out var currency)) return currency;

        throw new MoneyArgumentFormatException(nameof(Currency), $"ISO-4217 \"{RegexPattern}\"", value);
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

    public bool Equals(Currency? other)
    {
        return string.Compare(Value, other?.Value, StringComparison.CurrentCultureIgnoreCase) == 0;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Currency);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }
}

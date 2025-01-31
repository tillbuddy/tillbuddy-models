using System.Text.RegularExpressions;
using TillBuddy.Models.Exceptions;

namespace TillBuddy.Models;

/// <summary>
/// https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2
/// </summary>
public sealed class CountryCode : IEquatable<CountryCode>
{
    private const string RegexPattern = "^[a-zA-Z]{2}$";
    private static readonly Regex Regex = new(RegexPattern, RegexOptions.Compiled);

    public string Value { get; }

    public CountryCode()
    {
        Value = string.Empty;
    }

    public CountryCode(string value)
    {
        if (!string.IsNullOrEmpty(value) && !Regex.IsMatch(value))
        {
            throw new CountryArgumentFormatException(nameof(CountryCode), $"ISO 3166-1 alpha-2 (\"{RegexPattern}\")", value);
        }

        Value = value;

    }

    public static implicit operator string(CountryCode? countryCode)
    {
        return countryCode?.Value ?? string.Empty;
    }

    public static CountryCode Parse(string value)
    {
        if (TryParse(value, out var countryCode)) return countryCode;

        throw new CountryArgumentFormatException(nameof(CountryCode), $"ISO 3166-1 alpha-2 (\"{RegexPattern}\")", value);
    }

    public static bool TryParse(string value, out CountryCode countryCode)
    {
        if (string.IsNullOrEmpty(value))
        {
            countryCode = new CountryCode(string.Empty);
            return true;
        }

        if (Regex.IsMatch(value))
        {
            countryCode = new CountryCode(value);
            return true;
        }

        countryCode = new CountryCode();

        return false;
    }

    public override string ToString()
    {
        return Value;
    }

    public bool Equals(CountryCode? other)
    {
        if (Value != other?.Value) return false;

        return true;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as CountryCode);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }
}

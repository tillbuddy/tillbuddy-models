using System.Text.RegularExpressions;

namespace TillBuddy.Models;


/// <summary>
/// https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2
/// </summary>
public sealed class CountryCode : ValueObject
{
    private const string RegexPattern = "^[a-zA-Z]{2}$";
    private static readonly Regex Regex = new Regex(RegexPattern);

    public string Value { get; set; }

    public CountryCode()
    {
        Value = string.Empty;
    }

    public CountryCode(string value)
    {
        Value = value;
    }

    public static implicit operator string(CountryCode countryCode)
    {
        return countryCode.ToString();
    }

    public static CountryCode Parse(string value)
    {
        if (TryParse(value, out var countryCode)) return countryCode;

        throw new ArgumentException($"ISO 3166-1 alpha-2 (\"{RegexPattern}\")", nameof(CountryCode));
    }

    public static bool TryParse(string value, out CountryCode countryCode)
    {
        countryCode = new CountryCode();

        if (value == null) return false;

        var matches = Regex.Matches(value);
        if (matches.Count == 1)
        {
            countryCode = new CountryCode(value);
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

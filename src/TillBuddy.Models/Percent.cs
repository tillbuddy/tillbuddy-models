using System.Globalization;
using System.Text.RegularExpressions;
using TillBuddy.Models.Exceptions;

namespace TillBuddy.Models;

public sealed class Percent : IEquatable<Percent>
{
    private const string RegexPattern = "((?<number>.+)%$)";
    private static readonly Regex Regex = new Regex(RegexPattern);

    /// <summary>
    /// The value as percentage. E.g. 25% will be represented as 0.25
    /// </summary>
    public decimal Percentage { get; set; }

    /// <summary>
    /// The value in percent. E.g. 25% will be represented as 25
    /// </summary>
    public decimal Number { get; set; }

    public Percent() { }

    private Percent(decimal percentage)
    {
        Percentage = percentage;
        Number = percentage * 100;
    }

    public static Percent FromPercentage(decimal percentage)
    {
        return new Percent(percentage);
    }

    public static Percent FromNumber(decimal number)
    {
        return new Percent(number / 100);
    }

    public static Percent Parse(string value)
    {
        if (TryParse(value, out var percent))
            return percent;
        throw new PercentArgumentFormatException(nameof(Percent), $"\"{RegexPattern}\"", value);
    }

    public static bool TryParse(string value, out Percent percent)
    {
        percent = new Percent();

        if (value == null) return false;

        var matches = Regex.Matches(value);
        if (matches.Count == 1)
        {
            var numberValue = matches[0].Groups["number"].Value;

            if (decimal.TryParse(numberValue, NumberStyles.Number, CultureInfo.InvariantCulture, out var number))
            {
                percent = FromNumber(number);

                return true;
            }
        }

        return false;
    }

    public override string ToString()
    {
        return $"{Number.ToString("F2", CultureInfo.InvariantCulture)}%";
    }

    public bool Equals(Percent? other)
    {
        if (Percentage != other?.Percentage) return false;

        if (Number!= other.Number) return false;

        return true;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Percent);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Percentage, Number);
    }
}
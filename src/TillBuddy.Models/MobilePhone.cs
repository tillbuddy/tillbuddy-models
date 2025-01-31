using System.Text.RegularExpressions;
using TillBuddy.Models.Exceptions;

namespace TillBuddy.Models;

/// <summary>
/// https://en.wikipedia.org/wiki/E.164
/// </summary>
public sealed class MobilePhone
{
    private const string RegexPattern = @"^\+[0-9]\d{1,14}$";
    private static readonly Regex Regex = new(RegexPattern, RegexOptions.Compiled);

    public string Value { get; }

    public MobilePhone()
    {
        Value = string.Empty;
    }

    public MobilePhone(string value)
    {
        if (!string.IsNullOrEmpty(value) && !Regex.IsMatch(value))
        {
            throw new MobilePhoneArgumentFormatException(nameof(MobilePhone), $"E.164 (\"{RegexPattern}\") or empty string", value);
        }

        Value = value;
    }

    public static bool IsValid(string value) => !string.IsNullOrEmpty(value) && Regex.IsMatch(value);

    public static implicit operator string(MobilePhone? mobilePhone) => mobilePhone?.Value ?? string.Empty;

    public static implicit operator MobilePhone(string value) => new(value);

    public static MobilePhone Parse(string value)
    {
        if (TryParse(value, out var mobilePhone))
        {
            return mobilePhone;
        }

        throw new MobilePhoneArgumentFormatException(nameof(MobilePhone), $"E.164 (\"{RegexPattern}\")", value);
    }

    public static bool TryParse(string value, out MobilePhone mobilePhone)
    {
        if (string.IsNullOrEmpty(value) || Regex.IsMatch(value))
        {
            mobilePhone = new MobilePhone(value);
            return true;
        }

        mobilePhone = null!;
        return false;
    }

    public override string ToString() => Value;

    public override bool Equals(object? obj)
    {
        return obj is MobilePhone other && string.Equals(Value, other.Value, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode() => StringComparer.OrdinalIgnoreCase.GetHashCode(Value);

    public static bool operator ==(MobilePhone? left, MobilePhone? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.Value.Equals(right.Value, StringComparison.OrdinalIgnoreCase);
    }

    public static bool operator !=(MobilePhone? left, MobilePhone? right) => !(left == right);
}
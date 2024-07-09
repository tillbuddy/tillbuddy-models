using System.Text.RegularExpressions;
using TillBuddy.SDK.Model.Exceptions;

namespace TillBuddy.SDK.Model;

/// <summary>
/// https://en.wikipedia.org/wiki/E.164
/// </summary>
public sealed class MobilePhone : IEquatable<MobilePhone>
{
    private const string RegexPattern = "^\\+[1-9]\\d{1,14}$";
    private static readonly Regex Regex = new Regex(RegexPattern);

    public string Value { get; set; }

    public MobilePhone()
    {
        Value = string.Empty;
    }

    public MobilePhone(string value)
    {
        Value = value;
    }

    public static implicit operator string(MobilePhone mobilePhone)
    {
        return mobilePhone?.ToString() ?? string.Empty;
    }

    public static MobilePhone Parse(string value)
    {
        if (TryParse(value, out var mobilePhone)) return mobilePhone;

        throw new MobilePhoneArgumentFormatException(nameof(MobilePhone), $"E.164 (\"{RegexPattern}\")", value);
    }

    public static bool TryParse(string value, out MobilePhone mobilePhone)
    {
        mobilePhone = new MobilePhone();

        if (value == null) return false;

        var matches = Regex.Matches(value);
        if (matches.Count == 1)
        {
            mobilePhone = new MobilePhone(value);
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return Value;
    }

    public bool Equals(MobilePhone? other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as MobilePhone);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }
}

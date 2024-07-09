using System.Text.RegularExpressions;
using TillBuddy.SDK.Model.Exceptions;

namespace TillBuddy.SDK.Model;

/// <summary>
/// A very trivial and not a full implementation of the spec (https://tools.ietf.org/html/rfc5322#section-3.4)
/// </summary>
public sealed class EmailAddress : IEquatable<Currency>
{
    private const string RegexPattern = "^(?<localPart>[^@]+)@(?<domain>[^@]+)$";
    private static readonly Regex Regex = new Regex(RegexPattern);

    public string Value { get; set; }

    public EmailAddress()
    {
        Value = string.Empty;
    }

    private EmailAddress(string value)
    {
        Value = value;
    }

    public static implicit operator string(EmailAddress? emailAddress)
    {
        return emailAddress?.Value ?? string.Empty;
    }

    public static EmailAddress Parse(string value)
    {
        if (TryParse(value, out var email)) return email;

        throw new EmailAddressArgumentFormatException(nameof(EmailAddress), $"\"{RegexPattern}\"", value);
    }

    public static bool TryParse(string value, out EmailAddress emailAddress)
    {
        emailAddress = new EmailAddress();

        if (value == null) return false;

        var matches = Regex.Matches(value);
        if (matches.Count == 1)
        {
            emailAddress = new EmailAddress(value);
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
        return Value == other?.Value;
    }
}
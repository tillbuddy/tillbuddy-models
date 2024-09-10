using System;
using System.Text.RegularExpressions;
using TillBuddy.SDK.Model.Exceptions;

namespace TillBuddy.SDK.Model;

/// <summary>
/// A very trivial and not a full implementation of the spec (https://tools.ietf.org/html/rfc5322#section-3.4)
/// </summary>
public sealed class EmailAddress
{
    private const string RegexPattern = "^(?<localPart>[^@]+)@(?<domain>[^@]+)$";
    private static readonly Regex Regex = new Regex(RegexPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public string Value { get; }

    private EmailAddress(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Email address cannot be null or empty", nameof(value));
        }

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
        emailAddress = new EmailAddress(value);

        var matches = Regex.Matches(value);
        
        if (matches.Count == 1)
        {
            emailAddress = new EmailAddress(value);
            return true;
        }

        return false;
    }

    public override string ToString() => Value;

    public override int GetHashCode() => HashCode.Combine(Value);

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;

        if (obj == null || GetType() != obj.GetType()) return false;

        var other = (EmailAddress)obj;

        return IsEmailEqual(Value, other.Value);
    }

    private static bool IsEmailEqual(string first, string second)
    {
        return string.Equals(first, second, StringComparison.InvariantCultureIgnoreCase);
    }
}
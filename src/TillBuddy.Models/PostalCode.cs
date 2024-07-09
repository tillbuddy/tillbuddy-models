using System.Text.RegularExpressions;
using TillBuddy.SDK.Model.Exceptions;

namespace TillBuddy.SDK.Model;

public sealed class PostalCode : IEquatable<PostalCode>
{
    private const string RegexPattern = "^[A-Z0-9]+$";
    private static readonly Regex Regex = new Regex(RegexPattern);

    public string Value { get; set; }

    public PostalCode() 
    {
        Value = string.Empty;
    }

    public PostalCode(string value)
    {
        Value = value;
    }

    public static implicit operator string(PostalCode postalCode)
    {
        return postalCode.Value;
    }

    public static PostalCode Parse(string value)
    {
        if (TryParse(value, out var postalCode)) return postalCode;

        throw new PostalCodeArgumentFormatException(nameof(PostalCode), $"\"{RegexPattern}\"", value);
    }

    public static bool TryParse(string value, out PostalCode postalCode)
    {
        postalCode = new PostalCode();

        if (value == null) return false;

        var matches = Regex.Matches(value);
        if (matches.Count == 1)
        {
            postalCode = new PostalCode(value);
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return Value;
    }

    public bool Equals(PostalCode? other)
    {
        if (Value != other?.Value) return false;

        return true;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as PostalCode);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }
}

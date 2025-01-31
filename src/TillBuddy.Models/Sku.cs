using Ardalis.GuardClauses;

namespace TillBuddy.Models;

/// <summary>
/// Domain model for Stock Keeping Unit
/// </summary>
public sealed class Sku
{
    public string Value { get; set; } = null!;

    public Sku() 
    { 

    }

    public Sku(string value)
    {
        Guard.Against.NullOrEmpty(value, nameof(value));

        Value = value;
    }

    public static bool operator ==(Sku? left, Sku? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.Value.Equals(right.Value) && left.Value.Equals(right.Value);
    }
    public static bool operator !=(Sku? left, Sku? right)
    {
        return !(left == right);
    }

    public static Sku Parse(string value)
    {
        if (TryParse(value, out var sku)) return sku;

        throw new ArgumentNullException(nameof(value));
    }

    public static bool TryParse(string value, out Sku sku)
    {
        sku = new Sku();

        if (string.IsNullOrEmpty(value)) return false;

        sku = new Sku(value);
        return true;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(Sku sku)
    {
        return sku.ToString();
    }

    public static implicit operator Sku(string value) => new(value);
}
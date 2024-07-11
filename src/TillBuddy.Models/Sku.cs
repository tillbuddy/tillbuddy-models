using Dawn;

namespace TillBuddy.SDK.Model;

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
        Guard.Argument(() => value).NotNull().NotEmpty();

        Value = value;
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
}
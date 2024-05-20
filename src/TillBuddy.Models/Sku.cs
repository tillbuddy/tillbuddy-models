namespace TillBuddy.Models;

public class Sku
{
    public string Value { get; set; }

    public Sku() 
    {
        Value = null!;
    }

    public Sku(string value)
    {
        Value = value;
    }

    public static Sku Parse(string value)
    {
        if (TryParse(value, out var sku)) return sku;

        throw new ArgumentNullException();
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
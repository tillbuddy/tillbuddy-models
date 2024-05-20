namespace TillBuddy.Models;

public interface IDiscount
{
    public IMoney Money { get; set; }

    public decimal Percent { get; set; }

    public string Intention { get; set; }
}

public class Discount : IDiscount
{
    public IMoney Money { get; set; } = null!;

    public decimal Percent { get; set; }

    public string Intention { get; set; } = null!;
}

public class DiscountRequest : Discount
{
}

public class DiscountResponse : Discount
{
}

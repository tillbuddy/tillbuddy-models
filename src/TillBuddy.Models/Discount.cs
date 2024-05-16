namespace TillBuddy.Models;

public interface IDiscount
{
    public IMoney Money { get; set; }

    public decimal Percent { get; set; }

    public string Intention { get; set; }
}

public class DiscountRequest : IDiscount
{
    public IMoney Money { get; set; } = null!;

    public decimal Percent { get; set; }

    public string Intention { get; set; } = null!;
}

public class DiscountResponse : IDiscount
{
    public IMoney Money { get; set; } = null!;

    public decimal Percent { get; set; }

    public string Intention { get; set; } = null!;
}

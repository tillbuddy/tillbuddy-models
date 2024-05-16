namespace TillBuddy.Models;

public interface IMoney
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }
}

public class MoneyRequest : IMoney
{
    public decimal Amount { get; set; }

    public string Currency { get; set; } = null!;
}

public class MoneyResponse : IMoney
{
    public decimal Amount { get; set; }

    public string Currency { get; set; } = null!;
}

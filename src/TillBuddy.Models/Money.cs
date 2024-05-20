namespace TillBuddy.Models;

public interface IMoney
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }
}

public class Money : IMoney
{
    public decimal Amount { get; set; }

    public string Currency { get; set; } = null!;
}

public class MoneyRequest : Money
{
}

public class MoneyResponse : Money
{
}

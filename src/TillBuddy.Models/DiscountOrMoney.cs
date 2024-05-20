namespace TillBuddy.Models;

public interface IDiscountOrMoneyRequest
{
    public IMoney? Money { get; set; }

    public decimal? Percent { get; set; }

    public string? Intention { get; set; }

    public decimal? Amount { get; set; }

    public string? Currency { get; set; }
}

public class DiscountOrMoneyRequest
{
    public MoneyRequest? Money { get; set; }

    public decimal? Percent { get; set; }

    public string? Intention { get; set; }

    public decimal? Amount { get; set; }

    public string? Currency { get; set; }
}

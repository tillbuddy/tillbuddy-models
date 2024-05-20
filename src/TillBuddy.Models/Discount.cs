namespace TillBuddy.Models;

public interface IDiscount
{
    public IMoney Money { get; set; }

    public decimal Percent { get; set; }

    public string Intention { get; set; }
}

public partial class Discount : IDiscount
{
    public IMoney Money { get; set; } = null!;

    public decimal Percent { get; set; }

    public string Intention { get; set; } = null!;

    public Discount()
    {

    }

    public Discount(
        IMoney money,
        decimal percent,
        string intention)
    {
        Money = money;
        Percent = percent;
        Intention = intention;
    }
}

public class DiscountRequest : Discount
{
    public DiscountRequest(IMoney money, decimal percent, string intention) : base(money, percent, intention) { }

    public DiscountRequest() : base() { }
}

public class DiscountResponse : Discount
{
    public DiscountResponse(IMoney money, decimal percent, string intention) : base(money, percent, intention) { }

    public DiscountResponse() : base() { }
}

public static class DiscountMapper
{
    public static DiscountRequest? MapToRequest(this IDiscount? discount)
    {
        if (discount == null)
        {
            return null;
        }

        var money = new Money(discount.Money.Amount, discount.Money.Currency);

        return new DiscountRequest(
            money,
            discount.Percent,
            discount.Intention);
    }

    public static DiscountResponse? MapToResponse(this IDiscount? discount)
    {
        if (discount == null)
        {
            return null;
        }

        var money = new Money(discount.Money.Amount, discount.Money.Currency);

        return new DiscountResponse(
            money,
            discount.Percent,
            discount.Intention);
    }
}
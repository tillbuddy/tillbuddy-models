namespace TillBuddy.Models;

public interface IPayment
{
    public string Type { get; set; }
    public IMoney Amount { get; set; }
    public DateTime Received { get; set; }
    public int? CardIssuerId { get; set; }
    public string? CardIssuerName { get; set; }
    public Guid? CreditNoteNumber { get; set; }
    public string? Vendor { get; set; }
    public ICardTransactionDetails? Transaction { get; set; }
}

public class Payment : IPayment
{
    public string Type { get; set; } = null!;
    public IMoney Amount { get; set; } = null!;
    public DateTime Received { get; set; }
    public int? CardIssuerId { get; set; } = null!;
    public string? CardIssuerName { get; set; }
    public Guid? CreditNoteNumber { get; set; }
    public string? Vendor { get; set; }
    public ICardTransactionDetails? Transaction { get; set; }
}

public class PaymentRequest : Payment
{

}

public class PaymentResponse : Payment
{

}
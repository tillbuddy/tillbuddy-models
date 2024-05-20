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

    public Payment(
       string type,
       Money amount,
       DateTime received,
       int? cardIssuerId,
       string? cardIssuerName,
       Guid? creditNoteNumber,
       string? vendor,
       ICardTransactionDetails? transaction)
    {
        Type = type;
        Amount = amount;
        Received = received;
        CardIssuerId = cardIssuerId;
        CardIssuerName = cardIssuerName;
        CreditNoteNumber = creditNoteNumber;
        Vendor = vendor;
        Transaction = transaction;
    }
}

public class PaymentRequest
{
    public string Type { get; set; } = null!;
    public string Amount { get; set; } = null!;
    public DateTime Received { get; set; }
    public int? CardIssuerId { get; set; }
    public string? CardIssuerName { get; set; } = null!;
    public Guid? CreditNoteNumber { get; set; }
    public string? Vendor { get; set; } = null!;
    public ICardTransactionDetails? Transaction { get; set; } = null!;
}

public class PaymentResponse
{
    public string Type { get; set; } = null!;
    public string Amount { get; set; } = null!;
    public DateTime Received { get; set; }
    public int? CardIssuerId { get; set; }
    public string? CardIssuerName { get; set; } = null!;
    public Guid? CreditNoteNumber { get; set; }
    public string? Vendor { get; set; } = null!;
    public ICardTransactionDetails? Transaction { get; set; } = null!;
}
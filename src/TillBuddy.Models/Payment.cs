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
       IMoney amount,
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


public static class PaymentMapper
{
    public static PaymentResponse MapToResponse(this IPayment source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        return new()
        {
            Type = source.Type,
            Amount = source.Amount.MapToString(),
            Received = source.Received,
            CardIssuerId = source.CardIssuerId,
            CardIssuerName = source.CardIssuerName,
            CreditNoteNumber = source.CreditNoteNumber,
            Vendor = source.Vendor,
            Transaction = source.Transaction?.MapToResponse(),
        };
    }

    public static PaymentRequest MapToRequest(this IPayment source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        return new()
        {
           Type = source.Type,
           Amount = source.Amount.MapToString(),
           Received = source.Received,
           CardIssuerId = source.CardIssuerId,
           CardIssuerName = source.CardIssuerName,
           CreditNoteNumber = source.CreditNoteNumber,
           Vendor = source.Vendor,
           Transaction = source.Transaction?.MapToRequest(),
        };
    }

    public static IEnumerable<PaymentRequest> MapToRequest(this IEnumerable<IPayment> payments)
    {
        foreach (var payment in payments)
        {
            yield return payment.MapToRequest();
        }
    }

    public static IEnumerable<PaymentResponse> MapToResponse(this IEnumerable<IPayment> payments)
    {
        foreach (var payment in payments)
        {
            yield return payment.MapToResponse();
        }
    }
}
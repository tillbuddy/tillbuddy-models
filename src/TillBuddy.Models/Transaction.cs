namespace TillBuddy.Models;

public interface ICardTransactionDetails
{
    public string? EcrTransactionId { get; set; }

    public string? TerminalTransactionId { get; set; }

    public string? AcquirerTransactionId { get; set; }
}

public class CardTransactionDetails : ICardTransactionDetails
{
    public string? EcrTransactionId { get; set; }

    public string? TerminalTransactionId { get; set; }

    public string? AcquirerTransactionId { get; set; }
}

public class CardTransactionDetailsRequest : CardTransactionDetails
{
}

public class TransactionResponse : CardTransactionDetails
{
}

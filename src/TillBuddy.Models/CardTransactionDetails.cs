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

    public CardTransactionDetails()
    {
        
    }

    public CardTransactionDetails(string? ecrTransactionId, string? terminalTransactionId, string? acquirerTransactionId)
    {
        EcrTransactionId = ecrTransactionId;
        TerminalTransactionId = terminalTransactionId;
        AcquirerTransactionId = acquirerTransactionId;
    }
}

public class CardTransactionDetailsRequest : CardTransactionDetails
{
}

public class TransactionResponse : CardTransactionDetails
{
}

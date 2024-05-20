namespace TillBuddy.Models;

public interface IReceiptNumber
{
    public string Type { get; set; }
    public string Value { get; set; }
    public int PosDevice { get; set; }
    public int Number { get; set; }
}

public class ReceiptNumber : IReceiptNumber
{
    public string Type { get; set; } = null!;
    public string Value { get; set; } = null!;
    public int PosDevice { get; set; }
    public int Number { get; set; }
}

public class ReceiptNumberRequest : ReceiptNumber
{
}

public class ReceiptNumberResponse : ReceiptNumber
{
}
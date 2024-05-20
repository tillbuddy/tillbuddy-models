using System.Text.RegularExpressions;

namespace TillBuddy.Models;

public interface IReceiptNumber
{
    public string Type { get; set; }
    public int PosDevice { get; set; }
    public int Sequence { get; }
}

public class ReceiptNumber : IReceiptNumber
{
    private const string PosDevicePattern = "[0-9]+";
    private const string SequencePattern = "[0-9]+";
    private static readonly string RegexPattern = $"^(?<posdevice>{PosDevicePattern})/(?<number>{SequencePattern})$";
    private static readonly Regex Regex = new Regex(RegexPattern);

    /// <summary>
    /// Receipt number
    /// </summary>
    public int Sequence { get; }
    public string Type { get; set; } = null!;
    public int PosDevice { get; set; }
    
    public string TypeAndValue => $"{Type}:{PosDevice}/{Sequence}";
    public string Value => $"{PosDevice}/{Sequence}";

    public ReceiptNumber() { }

    public ReceiptNumber(
       string type,
       int posdevice,
       int sequence)
    {
        Type = type;
        PosDevice = posdevice;
        Sequence = sequence;
    }

    public static ReceiptNumber Parse(
       string type,
       string value)
    {
        if (TryParse(type, value, out var receiptNumber))
            return receiptNumber;

        throw new Exception($"Invalid argument for {nameof(type)} and {nameof(value)}: \"{RegexPattern}\"");
    }

    public static bool TryParse(
        string type,
        string value,
        out ReceiptNumber receiptNumber)
    {
        receiptNumber = new ReceiptNumber();

        if (type == null) return false;

        if (value == null) return false;

        var matches = Regex.Matches(value);
        if (matches.Count != 1) return false;

        var matchedPosdevice = matches[0].Groups["posdevice"].Value;
        var matchedNumber = matches[0].Groups["number"].Value;

        if (!int.TryParse(matchedPosdevice, out int posdevice)) return false;

        if (!int.TryParse(matchedNumber, out int number)) return false;


        receiptNumber = new ReceiptNumber(type, posdevice, number);
        return true;
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(ReceiptNumber receiptNumber)
    {
        return receiptNumber.ToString();
    }
}

public class ReceiptNumberRequest : ReceiptNumber
{
}

public class ReceiptNumberResponse : ReceiptNumber
{
}
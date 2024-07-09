namespace TillBuddy.SDK.Model.Exceptions;

public class CurrencyMismatchException(string Current, string Compared) : Exception
{
    override public string Message => $"Money has different currency. Current: {Current}. Compared: {Compared}";
}

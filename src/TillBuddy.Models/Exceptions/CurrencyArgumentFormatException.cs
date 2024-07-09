namespace TillBuddy.SDK.Model.Exceptions;

public class CurrencyArgumentFormatException(string ArgumentName, string Format, string Value) : Exception
{
    override public string Message => $"Invalid format for currency. Argument: '{ArgumentName}' Value: '{Value}'. Expected format: '{Format}'.";
}

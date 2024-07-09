namespace TillBuddy.Models.Exceptions;

public class MoneyArgumentFormatException(string ArgumentName, string Format, string Value) : Exception
{
    override public string Message => $"Invalid format for money. Argument: '{ArgumentName}' Value: '{Value}'. Expected format: '{Format}'.";
}
    
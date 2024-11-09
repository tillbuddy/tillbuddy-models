namespace TillBuddy.Models.Exceptions;

public class EmailAddressArgumentFormatException(string ArgumentName, string Format, string Value) : Exception
{
    override public string Message => $"Invalid format for email address. Argument: '{ArgumentName}' Value: '{Value}'. Expected format: '{Format}'.";
}
    
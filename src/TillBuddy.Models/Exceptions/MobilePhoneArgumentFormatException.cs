namespace TillBuddy.Models.Exceptions;

public class MobilePhoneArgumentFormatException(string ArgumentName, string Format, string Value) : Exception
{
    override public string Message => $"Invalid format for mobile phone. Argument: '{ArgumentName}' Value: '{Value}'. Expected format: '{Format}'.";
}
    
namespace TillBuddy.SDK.Model.Exceptions;

public class PostalCodeArgumentFormatException(string ArgumentName, string Format, string Value) : Exception
{
    override public string Message => $"Invalid format for postal code. Argument: '{ArgumentName}' Value: '{Value}'. Expected format: '{Format}'.";
}
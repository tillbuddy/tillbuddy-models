namespace TillBuddy.SDK.Model.Exceptions;

public class CountryArgumentFormatException(string ArgumentName, string Format, string Value) : Exception
{
    override public string Message => $"Invalid format for country. Argument: '{ArgumentName}' Value: '{Value}'. Expected format: '{Format}'.";
}
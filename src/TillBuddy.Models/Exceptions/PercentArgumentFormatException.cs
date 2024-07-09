namespace TillBuddy.SDK.Model.Exceptions;

public class PercentArgumentFormatException(string ArgumentName, string Format, string Value) : Exception
{
    override public string Message => $"Invalid format for percent. Argument: '{ArgumentName}' Value: '{Value}'. Expected format: '{Format}'.";
}
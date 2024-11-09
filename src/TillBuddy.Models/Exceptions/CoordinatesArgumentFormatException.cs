namespace TillBuddy.Models.Exceptions;

public class CoordinatesArgumentFormatException(string coordinates) : Exception
{
    public string Coordinates { get; set; } = coordinates;

    override public string Message => $"Invalid format for coordinates: '{Coordinates}'. Expected format is '{{latitude}},{{longitude}}'.";
}
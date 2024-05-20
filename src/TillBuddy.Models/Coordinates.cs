namespace TillBuddy.Models;

public interface ICoordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class Coordinates : ICoordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class CoordinatesRequest : Coordinates
{
}

public class CoordinatesResponse : Coordinates
{
}

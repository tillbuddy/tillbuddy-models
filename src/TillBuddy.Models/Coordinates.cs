namespace TillBuddy.Models;

public interface ICoordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class CoordinatesRequest : ICoordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class CoordinatesResponse : ICoordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

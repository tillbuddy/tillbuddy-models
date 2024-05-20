using System.Globalization;

namespace TillBuddy.Models;

public interface ICoordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class Coordinates : ValueObject, ICoordinates
{
    private double _latitude;

    private double _longitude;

    public Coordinates()
    {

    }

    public Coordinates(string coordinates)
    {
        Parse(coordinates);
    }


    public Coordinates(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    /// <summary>
    /// Attempts to parse coordinates in "{latitude},{longitude}" format
    /// </summary>
    public static bool TryParse(string value, out Coordinates coordinates)
    {
        coordinates = null;

        if (value == null) return false;

        var parts = value.Split(',');

        if (parts.Length < 2) return false;

        var latitude = double.Parse(parts[0], CultureInfo.InvariantCulture);
        var longitude = double.Parse(parts[1], CultureInfo.InvariantCulture);

        if (!IsValidLatitude(latitude)) return false;
        if (!IsValidLongitude(longitude)) return false;

        coordinates = new Coordinates(latitude, longitude);
        return true;
    }


    /// <summary>
    /// Parses coordinates in "{latitude},{longitude}" format
    /// </summary>
    public static Coordinates Parse(string value)
    {
        if(string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));

        if (TryParse(value, out var coordinate)) return coordinate;

        throw new ArgumentException("\"{latitude},{longitude}\"", nameof(Coordinates));
    }

    private static bool IsValidLatitude(double latitude)
    {
        return !(latitude > 90.0 || latitude < -90.0);
    }

    private static bool IsValidLongitude(double longitude)
    {
        return !(longitude > 180.0 || longitude < -180.0);
    }

    public double Latitude
    {
        get
        {
            return _latitude;
        }
        set
        {
            if (!IsValidLatitude(_latitude))
            {
                throw new ArgumentOutOfRangeException("Latitude", "Argument must be in range of -90 to 90");
            }

            _latitude = value;
        }
    }

    public double Longitude
    {
        get
        {
            return _longitude;
        }
        set
        {
            if (!IsValidLongitude(value))
            {
                throw new ArgumentOutOfRangeException("Longitude", "Argument must be in range of -180 to 180");
            }

            _longitude = value;
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _longitude;
        yield return _latitude;
    }

    public override string ToString()
    {
        return string.Format("{0},{1}", Latitude.ToString("G", CultureInfo.InvariantCulture), Longitude.ToString("G", CultureInfo.InvariantCulture));
    }
}

public class CoordinatesRequest : Coordinates
{
}

public class CoordinatesResponse : Coordinates
{
}

public static class CoordinatesMapper
{
    public static CoordinatesResponse MapToResponse(this ICoordinates source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        return new()
        {
            Latitude = source.Latitude,
            Longitude = source.Longitude
        };
    }

    public static CoordinatesRequest MapToRequest(this ICoordinates source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        return new()
        {
            Latitude = source.Latitude,
            Longitude = source.Longitude
        };
    }
}
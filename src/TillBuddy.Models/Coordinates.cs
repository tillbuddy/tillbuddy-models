using Dawn;
using System.Globalization;
using TillBuddy.SDK.Model.Exceptions;

namespace TillBuddy.SDK.Model;

public sealed class Coordinates : IEquatable<Coordinates>
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
        coordinates = new Coordinates();

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
        Guard.Argument(value, nameof(value)).NotNull();

        if (TryParse(value, out var coordinate)) return coordinate;

        throw new CoordinatesArgumentFormatException(value);
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

    public bool Equals(Coordinates? other)
    {
        if(other == null) return false;
        float tolerance = 0.000001f; // apx 0.1 meter

        if (Math.Abs(Latitude - other.Latitude) > tolerance) return false;
        if (Math.Abs(Longitude - other.Longitude) > tolerance) return false;

        return true;
    }

    public static implicit operator string(Coordinates? coordinates)
    {
        return coordinates?.ToString() ?? string.Empty;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Coordinates);
    }

    public override string ToString()
    {
        return string.Format("{0},{1}", Latitude.ToString("G", CultureInfo.InvariantCulture), Longitude.ToString("G", CultureInfo.InvariantCulture));
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Latitude, Longitude);
    }
}

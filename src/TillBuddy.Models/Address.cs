#nullable enable
namespace TillBuddy.Models;

public interface IAddress
{
    public string AddressLine { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public ICoordinates? Location { get; set; }
    public string? Coordinates { get; set; }
}

public class Address : IAddress
{
    public string AddressLine { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    public ICoordinates? Location { get; set; }
    public string? Coordinates { get; set; }
}

public class AddressRequest : Address
{
}

public class AddressResponse : Address
{
}

public static class AddressMapper
{
    public static AddressResponse MapToResponse(this IAddress source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        return new()
        {
            AddressLine = source.AddressLine,
            City = source.City,
            PostalCode = source.PostalCode,
            Country = source.Country,
            Location = source.Location?.MapToResponse(),
            Coordinates = source.Coordinates
        };
    }

    public static AddressRequest MapToRequest(this IAddress source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        return new()
        {
            AddressLine = source.AddressLine,
            City = source.City,
            PostalCode = source.PostalCode,
            Country = source.Country,
            Location = source.Location?.MapToResponse(),
            Coordinates = source.Coordinates
        };
    }
}
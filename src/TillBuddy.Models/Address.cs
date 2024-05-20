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

    public Address()
    {

    }

    public Address(
        string addressLine,
        string city,
        string postalCode,
        string country,
        string? coordinates = null,
        Coordinates? location = null)
    {
        AddressLine = addressLine;
        City = city;
        PostalCode = postalCode;
        Country = country;
        Coordinates = coordinates;
        Location = location;
    }

}

public class AddressRequest : Address
{
    public AddressRequest() : base() { }

    public AddressRequest(string addressLine, string city, string postalCode, string country, string? coordinates = null, Coordinates? location = null) : base(addressLine, city, postalCode, country, coordinates, location) { }
}

public class AddressResponse : Address
{
    public AddressResponse() { }
    
    public AddressResponse(string addressLine, string city, string postalCode, string country, string? coordinates = null, Coordinates? location = null) : base(addressLine, city, postalCode, country, coordinates, location) { }
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
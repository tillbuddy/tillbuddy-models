namespace TillBuddy.Models;

public interface IAddress : ICloneable
{
    public string AddressLine { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public Coordinates? Location { get; set; }
    public string? Coordinates { get; set; }   
}

public class Address : IAddress
{
    public string AddressLine { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    public Coordinates? Location { get; set; }
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

    public AddressResponse MapToResponse()
    {
        return new()
        {
            AddressLine = AddressLine,
            City = City,
            PostalCode = PostalCode,
            Country = Country,
            Location = Location?.MapToResponse(),
            Coordinates = Coordinates
        };
    }
    public AddressRequest MapToRequest()
    {
        return new()
        {
            AddressLine = AddressLine,
            City = City,
            PostalCode = PostalCode,
            Country = Country,
            Location = Location?.MapToResponse(),
            Coordinates = Coordinates
        };
    }

    public object Clone()
    {
        return new Address
        {
            AddressLine = AddressLine,
            City = City,
            PostalCode = PostalCode,
            Country = Country,
            Coordinates = Coordinates,
            Location = Location != null ? null : (Coordinates?) Location.Clone()
        };
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

using Ardalis.GuardClauses;

namespace TillBuddy.Models;

public sealed class Address : IEquatable<Address>
{
    public Address()
    {
        AddressLine = string.Empty;
        City = string.Empty;
        PostalCode = new PostalCode();
        Country = new CountryCode();
    }

    public Address(
        string addressLine,
        string city,
        PostalCode postalCode,
        CountryCode country,
        string? coordinates = null,
        Coordinates? location = null)
    {

        Guard.Against.Null(addressLine, nameof(addressLine));
        Guard.Against.Null(city, nameof(city));
        Guard.Against.Null(postalCode, nameof(postalCode));
        Guard.Against.Null(country, nameof(country));

        AddressLine = addressLine;
        City = city;
        PostalCode = postalCode;
        Country = country;
        Coordinates = coordinates;
        Location = location;
    }

    public string AddressLine { get; set; } = null!;
    public string City { get; set; } = null!;
    public PostalCode PostalCode { get; set; } = null!;
    public CountryCode Country { get; set; } = null!;
    public Coordinates? Location { get; set; }
    public string? Coordinates { get; set; }

    public bool Equals(Address? other)
    {
        if (string.Compare(AddressLine, other?.AddressLine) != 0) return false;
        if (string.Compare(City, other?.City) != 0) return false;
        if (string.Compare(PostalCode, other?.PostalCode) != 0) return false;
        if (string.Compare(Country, other?.Country) != 0) return false;
        if (string.Compare(Coordinates, other?.Coordinates) != 0) return false;
        if (Location != other?.Location) return false;

        return true;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Address);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(AddressLine, City, PostalCode, Country, Coordinates, Location);
    }

    public AddressResponse ToResponse()
    {
        return new AddressResponse
        {
            AddressLine = AddressLine,
            City = City,
            PostalCode = PostalCode,
            Country = Country,
            Coordinates = Coordinates,
            Location = Location
        };
    }

    public static Address Parse(AddressRequest source)
    {
        return new Address
            (
                source.AddressLine,
                source.City,
                PostalCode.Parse(source.PostalCode),
                CountryCode.Parse(source.Country),
                source.Coordinates,
                source.Location != null ? new Coordinates(source.Location) : null
            );
    }
}


public class AddressRequest
{
    public string AddressLine { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string? Location { get; set; }
    public string? Coordinates { get; set; }
}

public class AddressResponse
{
    public string AddressLine { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string? Location { get; set; }
    public string? Coordinates { get; set; }
}



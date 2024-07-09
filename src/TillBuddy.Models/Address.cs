using Dawn;

namespace TillBuddy.Models;

public sealed class Address : IEquatable<Address>
{
    public Address()
    {
        
    }

    public Address(
        string addressLine,
        string city,
        PostalCode postalCode,
        CountryCode country,
        string? coordinates = null,
        Coordinates? location = null)
    {
        Guard.Argument(() => addressLine).NotNull().NotEmpty();
        Guard.Argument(() => city).NotNull().NotEmpty();
        Guard.Argument(() => postalCode).NotNull();
        Guard.Argument(() => country).NotNull();

        AddressLine = addressLine;
        City = city;
        PostalCode = postalCode;
        Country = country;
        Coordinates = coordinates;
        Location = location;
    }

    public string AddressLine { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;
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
}
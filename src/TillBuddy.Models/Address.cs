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

public class AddressRequest : IAddress
{
    public string AddressLine { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    public ICoordinates? Location { get; set; }
    public string? Coordinates { get; set; }
}

public class AddressResponse : IAddress
{
    public string AddressLine { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    public ICoordinates? Location { get; set; }
    public string? Coordinates { get; set; }
}
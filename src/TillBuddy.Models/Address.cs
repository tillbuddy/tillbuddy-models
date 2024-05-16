namespace TillBuddy.Models;

public class AddressRequest
{
    public string AddressLine { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    public CoordinatesRequest? Location { get; set; }
    public string? Coordinates { get; set; }
}

public class AddressResponse
{
    public string AddressLine { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    public CoordinatesResponse? Location { get; set; }
    public string? Coordinates { get; set; }
}
using Dawn;

namespace TillBuddy.SDK.Model;

public sealed class StoreContactInformation : IEquatable<StoreContactInformation>
{
    public Address PhysicalAddress { get; set; } = null!;
    public Address ContactAddress { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;

    public StoreContactInformation()
    {      
    }

    public StoreContactInformation(
        Address physicalAddress,
        Address contactAddress,
        string phone,
        string email)
    {
        Guard.Argument(() => physicalAddress).NotNull();
        Guard.Argument(() => contactAddress).NotNull();
        Guard.Argument(() => phone).NotNull();
        Guard.Argument(() => email).NotNull();

        PhysicalAddress = physicalAddress;
        ContactAddress = contactAddress;
        Phone = phone;
        Email = email;
    }

    protected IEnumerable<object> GetEqualityComponents()
    {
        yield return PhysicalAddress;
        if (ContactAddress != null) yield return ContactAddress;
        if (Phone != null) yield return Phone;
        if (Email != null) yield return Email;
    }

    public static StoreContactInformation Parse(StoreContactInformationRequest source)
    {
        //TODO: Add request / response / parse support on address
        return new (
            source.PhysicalAddress,
            source.ContactAddress,
            source.Phone,
            source.Email);
    }

    public StoreContactInformationResponse ToResponse()
    {
        return new StoreContactInformationResponse
        {
            PhysicalAddress = PhysicalAddress,
            ContactAddress = ContactAddress,
            Phone = Phone,
            Email = Email
        };
    }

    public bool Equals(StoreContactInformation? other)
    {
        if (PhysicalAddress != other?.PhysicalAddress) return false;
        if (ContactAddress != other?.ContactAddress) return false;
        if (Phone != other?.Phone) return false;
        if (Email != other?.Email) return false;

        return true;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as StoreContactInformation);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(PhysicalAddress, ContactAddress, Phone, Email);
    }
}

public class StoreContactInformationRequest
{
    public Address PhysicalAddress { get; set; } = null!;
    public Address ContactAddress { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;


}

public class StoreContactInformationResponse
{
    public Address PhysicalAddress { get; set; } = null!;
    public Address ContactAddress { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
}
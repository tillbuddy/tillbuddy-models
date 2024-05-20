namespace TillBuddy.Models;

public interface IStoreContactInformation
{
    public IAddress PhysicalAddress { get; set; }
    public IAddress ContactAddress { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}

public class StoreContactInformation : ValueObject, IStoreContactInformation
{    
    public IAddress PhysicalAddress { get; set; } = null!;
    public IAddress ContactAddress { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;

    public StoreContactInformation() { }

    public StoreContactInformation(IAddress physicalAddress,
                                   IAddress contactAddress,
                                   string phone,
                                   string email)
    {
        PhysicalAddress = physicalAddress;
        ContactAddress = contactAddress;
        Phone = phone;
        Email = email;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PhysicalAddress;
        yield return ContactAddress;
        yield return Phone;
        yield return Email;
    }
}

public class StoreContactInformationRequest : StoreContactInformation
{
    public StoreContactInformationRequest() { }
    public StoreContactInformationRequest(IAddress physicalAddress, IAddress contactAddress, string phone, string email) : base(physicalAddress, contactAddress, phone, email) { }
}

public class StoreContactInformationResponse : StoreContactInformation
{
    public StoreContactInformationResponse() { }
    public StoreContactInformationResponse(IAddress physicalAddress, IAddress contactAddress, string phone, string email) : base(physicalAddress, contactAddress, phone, email) { }
}

public static class StoreContactInformationMapper
{
    public static StoreContactInformationResponse MapToResponse(this IStoreContactInformation source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        return new()
        {
            PhysicalAddress = source.PhysicalAddress.MapToResponse(),
            ContactAddress = source.ContactAddress.MapToResponse(),
            Phone = source.Phone,
            Email = source.Email
        };
    }

    public static StoreContactInformationRequest MapToRequest(this IStoreContactInformation source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        return new()
        {
            PhysicalAddress = source.PhysicalAddress.MapToRequest(),
            ContactAddress = source.ContactAddress.MapToResponse(),
            Phone = source.Phone,
            Email = source.Email
        };
    }
}
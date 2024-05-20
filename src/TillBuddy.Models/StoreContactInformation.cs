using System.Net.NetworkInformation;

namespace TillBuddy.Models;

public interface IStoreContactInformation
{
    public IAddress PhysicalAddress { get; set; }
    public IAddress ContactAddress { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}

public class StoreContactInformation
{
    public IAddress PhysicalAddress { get; set; } = null!;
    public IAddress ContactAddress { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
}

public class StoreContactInformationRequest : StoreContactInformation
{
}

public class StoreContactInformationResponse : StoreContactInformation
{
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

    public static string MapToString(this IMoney source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        return new Money(source.Amount, source.Currency).ToString();
    }
}
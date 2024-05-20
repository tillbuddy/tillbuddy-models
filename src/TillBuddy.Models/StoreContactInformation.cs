namespace TillBuddy.Models;

public interface IStoreContactInformationRequest
{
    public IAddress PhysicalAddress { get; set; }
    public IAddress ContactAddress { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}


public class StoreContactInformationRequest
{
    public IAddress PhysicalAddress { get; set; } = null!;
    public IAddress ContactAddress { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
}

public class StoreContactInformationResponse
{
    public IAddress PhysicalAddress { get; set; } = null!;
    public IAddress ContactAddress { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
}

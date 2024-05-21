namespace TillBuddy.Models;

public interface ISyncStatusSuccess
{
    public Guid TenantId { get; set; }
    public string Id { get; set; }
    public string ExternalId { get; set; }

}

public class SyncStatusSuccess : ISyncStatusSuccess
{
    public Guid TenantId { get; set; }
    public string Id { get; set; } = null!;
    public string ExternalId { get; set; } = null!;

    public SyncStatusSuccess()
    {
        
    }

    public SyncStatusSuccess(
        Guid tenantId,
        string id,
        string externalId)
    {
        if (tenantId == Guid.Empty) throw new ArgumentNullException(nameof(tenantId));
        TenantId = tenantId;
        if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
        Id = id;
        ExternalId = externalId ?? throw new ArgumentNullException(nameof(externalId));
    }

    public static SyncStatusSuccess Parse(ISyncStatusSuccess source)
    {
        return new SyncStatusSuccess()
        {
            ExternalId = source.ExternalId,
            Id = source.Id,
            TenantId = source.TenantId
        };
    }
}

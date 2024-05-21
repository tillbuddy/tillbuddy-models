namespace TillBuddy.Models;

public interface ISyncStatusFail
{
    public Guid TenantId { get; set; }
    public string Id { get; set; }
    public string ExternalId { get; set; }
    public string Reason { get; set; }
}

public class SyncStatusFail : ISyncStatusFail
{
    public Guid TenantId { get; set; }
    public string Id { get; set; } = null!;
    public string ExternalId { get; set; } = null!;
    public string Reason { get; set; } = null!;

    public SyncStatusFail()
    {
        
    }

    public SyncStatusFail(
        Guid tenantId,
        string id,
        string externalId,
        string reason)
    {
        if (tenantId == default) throw new ArgumentNullException(nameof(tenantId));
        TenantId = tenantId;
        Id = id;
        ExternalId = externalId ?? throw new ArgumentNullException(nameof(externalId));
        Reason = reason;
    }

    public static SyncStatusFail Parse(ISyncStatusFail source)
    {
        return new SyncStatusFail()
        {
            ExternalId = source.ExternalId,
            Id = source.Id,
            Reason = source.Reason,
            TenantId = source.TenantId
        };
    }
}

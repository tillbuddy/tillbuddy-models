namespace TillBuddy.SDK.Model;

public class SyncStatusResponse
{
    public List<SyncStatusSuccess> Success { get; set; } = [];
    public List<SyncStatusFail> Fail { get; set; } = [];
}

public class SyncStatusSuccess
{
    public Guid TenantId { get; set; }
    public string Id { get; set; }
    public string ExternalId { get; set; }

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
}

public class SyncStatusFail
{
    public Guid TenantId { get; set; }
    public string Id { get; set; }
    public string ExternalId { get; set; }
    public string Reason { get; set; }

    public SyncStatusFail(
        Guid tenantId,
        string id,
        string externalId,
        string reason)
    {
        if (tenantId == Guid.Empty) throw new ArgumentNullException(nameof(tenantId));
        TenantId = tenantId;
        Id = id;
        ExternalId = externalId ?? throw new ArgumentNullException(nameof(externalId));
        Reason = reason;
    }
}

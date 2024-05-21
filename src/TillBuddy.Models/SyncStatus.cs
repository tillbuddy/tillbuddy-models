namespace TillBuddy.Models;

public interface ISyncStatus
{
    public IEnumerable<SyncStatusSuccess> Success { get; }
    public IEnumerable<SyncStatusFail> Fail { get; }
}

public class SyncStatus : ISyncStatus
{
    protected List<SyncStatusSuccess> _success { get; set; } = new();
    protected List<SyncStatusFail> _fail { get; set; } = new();
    
    public IEnumerable<SyncStatusSuccess> Success
    {
        get { return _success; }
    }

    public IEnumerable<SyncStatusFail> Fail
    {
        get { return _fail; }
    }

    public void Add(SyncStatusSuccess success)
    {
        _success.Add(success);
    }

    public void Add(SyncStatusFail fail)
    {
        _fail.Add(fail);
    }
}

public class SyncStatusResponse : SyncStatus
{
}

public class SyncStatusRequest : SyncStatus
{   
}
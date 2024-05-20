namespace TillBuddy.Models;

public interface ISyncStatus
{
    public IEnumerable<ISyncStatusSuccess> Success { get; }
    public IEnumerable<ISyncStatusFail> Fail { get; }
}

public class SyncStatus : ISyncStatus
{
    protected List<ISyncStatusSuccess> _success { get; set; } = new();
    protected List<ISyncStatusFail> _fail { get; set; } = new();
    
    public IEnumerable<ISyncStatusSuccess> Success
    {
        get { return _success; }
    }

    public IEnumerable<ISyncStatusFail> Fail
    {
        get { return _fail; }
    }

    public void Add(ISyncStatusSuccess success)
    {
        _success.Add(success);
    }

    public void Add(ISyncStatusFail fail)
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
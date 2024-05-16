namespace TillBuddy.Models;

public enum JobStatus
{
    Pending,
    Running,
    Success,
    Failed,
    Scheduled,
    Canceling,
    Canceled,
    Skipped,
    Expired,
    Paused
}
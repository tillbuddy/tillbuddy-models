namespace TillBuddy.Models;

public interface IPeriod
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}

public class PeriodRequest : IPeriod
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }   
}

public class PeriodResponse : IPeriod
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}

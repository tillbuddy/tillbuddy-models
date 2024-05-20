namespace TillBuddy.Models;

public interface IPeriod
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}

public class Period : IPeriod
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}

public class PeriodRequest : Period
{
    public PeriodRequest()
    {

    }

    public PeriodRequest(DateTime from, DateTime to)
    {
        From = from;
        To = to;
    }

   
}

public class PeriodResponse : Period
{
    public PeriodResponse()
    {
        
    }

    public PeriodResponse(DateTime from, DateTime to)
    {
        From = from;
        To = to;
    }
}

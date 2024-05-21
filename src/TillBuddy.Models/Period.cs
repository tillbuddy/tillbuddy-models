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

    public Period()
    {

    }

    public Period(DateTime from, DateTime to)
    {
        From = from;
        To = to;
    }

    public static Period Parse(IPeriod source)
    {
        return new Period(source.From, source.To);
    }
}

public class PeriodRequest : Period
{
    public PeriodRequest() { }

    public PeriodRequest(DateTime from, DateTime to) : base(from, to) { }
}

public class PeriodResponse : Period
{
    public PeriodResponse() { }

    public PeriodResponse(DateTime from, DateTime to) : base(from, to) { }
}

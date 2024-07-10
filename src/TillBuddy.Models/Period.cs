namespace TillBuddy.SDK.Model;

public sealed class Period(
    DateTime from,
    DateTime to) : IEquatable<Period>
{
    public DateTime From { get; set; } = from;
    public DateTime To { get; set; } = to;

    public PeriodResponse ToResponse()
    {
        return new PeriodResponse(From, To);
    }

    public static Period Parse(PeriodRequest source)
    {
        return new Period(source.From, source.To);
    }

    public bool Equals(Period? other)
    {
        if (other == null) return false;

        if (From != other.From) return false;
        if (To != other.To) return false;

        return true;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Period);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(From, To);
    }
}

public class PeriodRequest
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public PeriodRequest()
    {

    }

    public PeriodRequest(
        DateTime from,
        DateTime to)
    {
        From = from;
        To = to;
    }
}

public class PeriodResponse
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public PeriodResponse()
    {
        
    }

    public PeriodResponse(
        DateTime from,
        DateTime to)
    {
        From = from;
        To = to;
    }
}

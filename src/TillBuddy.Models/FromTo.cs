namespace TillBuddy.Models;

public class FromTo<T>(T from, T to) where T : IComparable<T>
{
    public T From { get; set; } = from;
    public T To { get; set; } = to;

    public FromToResponse<T> ToResponse()
    {
        return new FromToResponse<T>
        {
            From = From,
            To = To
        };
    }

    public static FromTo<T> FromRequest(FromToRequest<T> request)
    {
        return new FromTo<T>(request.From, request.To);
    }
}

public class FromToRequest<T>
{
    public T From { get; set; } = default!;
    public T To { get; set; } = default!;
}

public class FromToResponse<T>  
{
    public T From { get; set; } = default!;
    public T To { get; set; } = default!;
}
namespace TillBuddy.Models;

public interface IPadding
{
    int Top { get; }
    int Right { get; }
    int Bottom { get; }
    int Left { get; }
}

public class Padding : IPadding
{
    public int Top { get; set; }
    public int Right { get; set; }
    public int Bottom { get; set; }
    public int Left { get; set; }

    public Padding Parse(IPadding source)
    {
        return new()
        {
            Top = source.Top,
            Right = source.Right,
            Bottom = source.Bottom,
            Left = source.Left
        };
    }
}

public class PaddingRequest : Padding
{
}

public class PaddingResponse : Padding
{
}
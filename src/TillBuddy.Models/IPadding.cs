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
}

public class PaddingRequest : Padding
{
}

public class PaddingResponse : Padding
{
}
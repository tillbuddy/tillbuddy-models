namespace TillBuddy.Models;


public interface IImageProperties
{
    int Width { get; }
    int? Height { get; }
    string? ResizingType { get; }
    Padding? Padding { get; }
    string? BackgroundColor { get; }
}

public class ImageProperties : IImageProperties
{
    public int Width { get; set; }
    public int? Height { get; set; }
    public string? ResizingType { get; set; }
    public Padding? Padding { get; set; }
    public string? BackgroundColor { get; set; }
}

public class ImagePropertiesRequest : ImageProperties
{
}
public class ImagePropertiesResponse : ImageProperties
{
}
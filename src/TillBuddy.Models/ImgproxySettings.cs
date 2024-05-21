using System.Text.Json.Serialization;

namespace TillBuddy.Models;

public interface IImgproxySettings
{
    string Key { get; }
    string Salt { get; }
    string? DefaultFormat { get; }
    int? DefaultQuality { get; }
    string BaseUrl { get; }
    Dictionary<string, ImageProperties> Presets { get; }
}

public class ImgproxySettings : IImgproxySettings
{
    public string Key { get; set; } = null!;
    public string Salt { get; set; } = null!;
    public string? DefaultFormat { get; set; } = null!;
    public int? DefaultQuality { get; set; }
    public string BaseUrl { get; set; } = null!;
    public Dictionary<string, ImageProperties> Presets { get; set; } = new ();
}

public class ImgproxySettingsRequest : ImgproxySettings
{   
}

public class ImgproxySettingsResponse : ImgproxySettings
{
}
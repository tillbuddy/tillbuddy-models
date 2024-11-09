using System.Text.Json.Serialization;

namespace TillBuddy.Models;

public class AssetReference : ICloneable
{
    [JsonPropertyName("group")]
    public string Group { get; set; } = string.Empty;
    /// <summary>
    /// An asset can point to an asset or an external url
    /// </summary>
    [JsonPropertyName("assetId")]
    public Guid? AssetId { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; } = null!;

    [JsonPropertyName("url")]
    public string Url { get; set; } = null!;

    public object Clone()
    {
        return new AssetReference
        {
            Group = Group,
            AssetId = AssetId,
            Text = Text,
            Url = Url
        };
    }
}
using System.Text.Json.Serialization;

namespace TillBuddy.Models;

public interface ILocalizedAssetReference : ICloneable
{
    [JsonPropertyName("group")]
    public string Group { get; set; }

    /// <summary>
    /// An asset can point to an asset or an external url
    /// </summary>
    [JsonPropertyName("assetId")]
    public Guid? AssetId { get; set; }

    [JsonPropertyName("text")]
    public ILocalizedText Text { get; set; }

    [JsonPropertyName("url")]
    public ILocalizedText Url { get; set; }
}

public class LocalizedAssetReference : ILocalizedAssetReference
{
    [JsonPropertyName("group")]
    public string Group { get; set; } = string.Empty;

    /// <summary>
    /// An asset can point to an asset or an external url
    /// </summary>
    [JsonPropertyName("assetId")]
    public Guid? AssetId { get; set; }

    [JsonPropertyName("text")]
    public ILocalizedText Text { get; set; } = null!;

    [JsonPropertyName("url")]
    public ILocalizedText Url { get; set; } = null!;

    public object Clone()
    {
        var clone = new LocalizedAssetReference
        {
            Group = Group,
            AssetId = AssetId,
            Text = new LocalizedText(Text),
            Url = new LocalizedText(Url)
        };

        return clone;
    }
}

public class LocalizedAssetReferenceRequest : LocalizedAssetReference
{
}

public class LocalizedAssetReferenceResponse : LocalizedAssetReference
{ 
}

using System.Text.Json.Serialization;

namespace TillBuddy.Models;

public interface ILocalizedAssetReference
{
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

public class LocalizedAssetReferenceRequest : ILocalizedAssetReference
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
}

public class LocalizedAssetReferenceResponse : ILocalizedAssetReference
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
}

using System.Text.Json.Serialization;

namespace TillBuddy.Models;

public interface IAssetReference
{
    [JsonPropertyName("group")]
    public string Group { get; set; }
    /// <summary>
    /// An asset can point to an asset or an external url
    /// </summary>
    [JsonPropertyName("assetId")]
    public Guid? AssetId { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class AssetReference : IAssetReference
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
}

public class AssetReferenceRequest : AssetReference
{       
}

public class AssetReferenceResponse : AssetReference
{
}

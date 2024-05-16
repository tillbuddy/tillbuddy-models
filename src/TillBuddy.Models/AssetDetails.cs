using System.Text.Json.Serialization;

namespace TillBuddy.Models;

public interface IAssetDetails
{
    [JsonPropertyName("assetId")]
    public string AssetId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("altText")]
    public string AltText { get; set; }

    [JsonPropertyName("assetType")]
    public string AssetType { get; set; }

    [JsonPropertyName("purpose")]
    public string Purpose { get; set; }

    [JsonPropertyName("filename")]
    public string Filename { get; set; }

    [JsonPropertyName("contentType")]
    public string ContentType { get; set; }

    [JsonPropertyName("fileSize")]
    public string FileSize { get; set; }

    [JsonPropertyName("attributes")]
    public IDictionary<string, string> Attributes { get; set; }

    [JsonPropertyName("tags")]
    public IEnumerable<string> Tags { get; set; }
}

public class AssetDetailsRequest : IAssetDetails
{
    [JsonPropertyName("assetId")]
    public string AssetId { get; set; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;

    [JsonPropertyName("url")]
    public string Url { get; set; } = null!;

    [JsonPropertyName("altText")]
    public string AltText { get; set; } = null!;

    [JsonPropertyName("assetType")]
    public string AssetType { get; set; } = null!;

    [JsonPropertyName("purpose")]
    public string Purpose { get; set; } = null!;

    [JsonPropertyName("filename")]
    public string Filename { get; set; } = null!;

    [JsonPropertyName("contentType")]
    public string ContentType { get; set; } = null!;

    [JsonPropertyName("fileSize")]
    public string FileSize { get; set; } = null!;

    [JsonPropertyName("attributes")]
    public IDictionary<string, string> Attributes { get; set; } = null!;

    [JsonPropertyName("tags")]
    public IEnumerable<string> Tags { get; set; } = null!;
}

public class AssetDetailsResponse : IAssetDetails
{
    [JsonPropertyName("assetId")]
    public string AssetId { get; set; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;

    [JsonPropertyName("url")]
    public string Url { get; set; } = null!;

    [JsonPropertyName("altText")]
    public string AltText { get; set; } = null!;

    [JsonPropertyName("assetType")]
    public string AssetType { get; set; } = null!;

    [JsonPropertyName("purpose")]
    public string Purpose { get; set; } = null!;

    [JsonPropertyName("filename")]
    public string Filename { get; set; } = null!;

    [JsonPropertyName("contentType")]
    public string ContentType { get; set; } = null!;

    [JsonPropertyName("fileSize")]
    public string FileSize { get; set; } = null!;

    [JsonPropertyName("attributes")]
    public IDictionary<string, string> Attributes { get; set; } = null!;

    [JsonPropertyName("tags")]
    public IEnumerable<string> Tags { get; set; } = null!;
}

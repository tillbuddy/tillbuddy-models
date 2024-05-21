using System.Text.Json.Serialization;

namespace TillBuddy.Models;

public class LocalizedAssetDetails : ICloneable
{
    [JsonPropertyName("assetId")]
    public string AssetId { get; set; } = null!;
    
    [JsonPropertyName("name")]
    public LocalizedText Name { get; set; } = null!;

    [JsonPropertyName("description")] 
    public LocalizedText Description { get; set; } = null!;

    [JsonPropertyName("url")]
    public LocalizedText Url { get; set; } = null!;

    [JsonPropertyName("altText")]
    public LocalizedText AltText { get; set; } = null!;

    [JsonPropertyName("assetType")]
    public string AssetType { get; set; } = null!;

    [JsonPropertyName("purpose")]
    public string Purpose { get; set; } = null!;

    [JsonPropertyName("filename")]
    public LocalizedText Filename { get; set; } = null!;

    [JsonPropertyName("contentType")]
    public string ContentType { get; set; } = null!;

    [JsonPropertyName("fileSize")]
    public LocalizedText FileSize { get; set; } = null!;

    [JsonPropertyName("attributes")]
    public Dictionary<string, Attribute> Attributes { get; set; } = null!;

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; } = null!;

    public object Clone()
    {
        var attribute = new Dictionary<string, Attribute>(StringComparer.InvariantCultureIgnoreCase);

        foreach (var (key, value) in Attributes)
        {
            attribute[key] = (Attribute) value.Clone();
        }

        return new LocalizedAssetDetails
        {
            AssetId = AssetId,
            Name = (LocalizedText) (Name?.Clone() ?? new()),
            Description = (LocalizedText) (Description?.Clone() ?? new()),
            Url = (LocalizedText) (Url?.Clone() ?? new()),
            AltText = (LocalizedText) (AltText?.Clone() ?? new()),  
            AssetType = AssetType,
            Purpose = Purpose,
            Filename = (LocalizedText) (Filename?.Clone() ?? new()),
            ContentType = ContentType,
            FileSize = (LocalizedText) (FileSize?.Clone() ?? new()),
            Attributes = new Dictionary<string, Attribute>(Attributes),
            Tags = new List<string>(Tags)
        };
    }
}

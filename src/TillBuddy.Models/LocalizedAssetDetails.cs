namespace TillBuddy.SDK.Model;

public class LocalizedAssetDetails : ICloneable
{
    public string AssetId { get; set; } = null!;
    
    public LocalizedText Name { get; set; } = null!;

    public LocalizedText Description { get; set; } = null!;

    public LocalizedText Url { get; set; } = null!;

    public LocalizedText AltText { get; set; } = null!;

    public string AssetType { get; set; } = null!;

    public string Purpose { get; set; } = null!;

    public LocalizedText Filename { get; set; } = null!;

    public string ContentType { get; set; } = null!;

    public LocalizedText FileSize { get; set; } = null!;

    public Dictionary<string, Attribute> Attributes { get; set; } = null!;

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

namespace TillBuddy.Models;

public class AssetDetails : ICloneable
{
    public string AssetId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string AltText { get; set; } = null!;
    public string AssetType { get; set; } = null!;
    public string Purpose { get; set; } = null!;
    public string Filename { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public string FileSize { get; set; } = null!;
    public Dictionary<string, string> Attributes { get; set; } = null!;
    public List<string> Tags { get; set; } = null!;

    public object Clone()
    {
        var clone = new AssetDetails
        {
            AltText = AltText,
            AssetId = AssetId,  
            AssetType = AssetType,
            ContentType = ContentType,
            Description = Description,
            Filename = Filename,
            FileSize = FileSize,
            Name = Name,
            Purpose = Purpose,
            Tags = new List<string>(Tags),
            Url = Url
        };

        if (Attributes != null)
        {
            clone.Attributes = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

            foreach (var (key, value) in Attributes)
            {
                clone.Attributes[key] = value;
            }
        }

        return clone;
    }
}
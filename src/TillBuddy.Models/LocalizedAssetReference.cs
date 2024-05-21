namespace TillBuddy.Models;

public interface ILocalizedAssetReference : ICloneable
{
    public string Group { get; set; }

    /// <summary>
    /// An asset can point to an asset or an external url
    /// </summary>
    public Guid? AssetId { get; set; }
    public LocalizedText Text { get; set; }
    public LocalizedText Url { get; set; }
}

public class LocalizedAssetReference : ILocalizedAssetReference
{
    public string Group { get; set; } = string.Empty;

    /// <summary>
    /// An asset can point to an asset or an external url
    /// </summary>
    public Guid? AssetId { get; set; }
    public LocalizedText Text { get; set; } = null!;
    public LocalizedText Url { get; set; } = null!;

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

    public static LocalizedAssetReference Parse(ILocalizedAssetReference source)
    {
        return new()
        {
            AssetId = source.AssetId,
            Group = source.Group,
            Text = (LocalizedText) source.Text.Clone(),
            Url = (LocalizedText) source.Url.Clone()
        };
    }
}

public class LocalizedAssetReferenceRequest : LocalizedAssetReference
{
}

public class LocalizedAssetReferenceResponse : LocalizedAssetReference
{ 
}

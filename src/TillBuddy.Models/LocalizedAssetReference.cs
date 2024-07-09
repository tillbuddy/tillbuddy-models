using System.Text.Json.Serialization;

namespace TillBuddy.Models;

public class LocalizedAssetReference : ICloneable
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
            Text = (LocalizedText) (Text?.Clone() ?? new()),
            Url = (LocalizedText) (Url?.Clone() ?? new())
        };

        return clone;
    }
}

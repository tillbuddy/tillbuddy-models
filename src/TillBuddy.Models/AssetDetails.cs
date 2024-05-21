namespace TillBuddy.Models;

public interface IAssetDetails
{
    public string AssetId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public string AltText { get; set; }
    public string AssetType { get; set; }
    public string Purpose { get; set; }
    public string Filename { get; set; }
    public string ContentType { get; set; }
    public string FileSize { get; set; }
    public IDictionary<string, string> Attributes { get; set; }
    public IEnumerable<string> Tags { get; set; }    
}

public class AssetDetails : IAssetDetails
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
    public IDictionary<string, string> Attributes { get; set; } = null!;
    public IEnumerable<string> Tags { get; set; } = null!;

    public AssetDetailsResponse MapToResponse()
    {
        return new()
        {
            AltText = AltText,
            AssetType = AssetType,
            AssetId = AssetId,
            Attributes = Attributes.Clone(),
            ContentType = ContentType,
            Description = Description,
            Filename = Filename,
            FileSize = FileSize,
            Name = Name,
            Purpose = Purpose,
            Tags = Tags.ToList(),
            Url = Url
        };
    }
    public AssetDetailsRequest MapToRequest()
    {
        return new()
        {
            AltText = AltText,
            AssetType = AssetType,
            AssetId = AssetId,
            Attributes = Attributes.Clone(),
            ContentType = ContentType,
            Description = Description,
            Filename = Filename,
            FileSize = FileSize,
            Name = Name,
            Purpose = Purpose,
            Tags = Tags.ToList(),
            Url = Url
        };
    }
}

public class AssetDetailsRequest : AssetDetails
{  
}

public class AssetDetailsResponse : AssetDetails
{
}

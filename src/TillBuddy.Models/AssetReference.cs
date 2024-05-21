namespace TillBuddy.Models;

public interface IAssetReference
{
    public string Group { get; set; }
    /// <summary>
    /// An asset can point to an asset or an external url
    /// </summary>
    public Guid? AssetId { get; set; }

    public string Text { get; set; }

    public string Url { get; set; }

    public AssetReferenceResponse MapToResponse()
    {
        return new()
        {
            AssetId = AssetId,
            Text = Text,
            Url = Url,
        };
    }
    public AssetReferenceRequest MapToRequest()
    {
        return new()
        {
            AssetId = AssetId,
            Text = Text,
            Url = Url,
        };
    }
}

public class AssetReference : IAssetReference
{
    public string Group { get; set; } = string.Empty;
    /// <summary>
    /// An asset can point to an asset or an external url
    /// </summary>
    public Guid? AssetId { get; set; }

    public string Text { get; set; } = null!;

    public string Url { get; set; } = null!;

    public AssetReference Parse(IAssetReference source)
    {
        return new()
        {
            AssetId = source.AssetId,
            Text = source.Text,
            Url = source.Url,
        };
    }

    public AssetReferenceResponse MapToResponse()
    {
        return ((IAssetReference)this).MapToResponse();
    }

    public AssetReferenceRequest MapToRequest()
    {
        return ((IAssetReference)this).MapToRequest();
    }
}

public class AssetReferenceRequest : AssetReference
{       
}

public class AssetReferenceResponse : AssetReference
{
}

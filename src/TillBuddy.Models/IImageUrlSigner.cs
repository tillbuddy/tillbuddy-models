namespace TillBuddy.Models;

public interface IImageUrlSigner
{
    Dictionary<string, string> CreatePresets(string url);
}

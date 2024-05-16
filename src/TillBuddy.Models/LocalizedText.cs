namespace TillBuddy.Models;

public interface ILocalizedText
{
    public string Text { get; set; }
    public bool UseTranslation { get; set; }
    public IDictionary<string, string> Translations { get; set; }
}

public class LocalizedTextRequest : ILocalizedText
{
    public string Text { get; set; } = null!;
    public bool UseTranslation { get; set; }
    public IDictionary<string, string> Translations { get; set; } = null!;
}

public class LocalizedTextResponse : ILocalizedText
{
    public string Text { get; set; } = null!;
    public bool UseTranslation { get; set; }
    public IDictionary<string, string> Translations { get; set; } = null!;
}

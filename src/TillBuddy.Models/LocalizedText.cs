namespace TillBuddy.Models;

public interface ILocalizedText
{
    public string Text { get; set; }
    public bool UseTranslation { get; set; }
    public IDictionary<string, string> Translations { get; set; }
    public string this[string key] { get;set; }
}

public class LocalizedTextRequest : ILocalizedText
{
    public string Text { get; set; } = null!;
    public bool UseTranslation { get; set; }
    public IDictionary<string, string> Translations { get; set; } = null!;

    public string this[string key]
    {
        get
        {
            if (UseTranslation)
            {
                if (Translations.TryGetValue(key, out var value))
                {
                    return value;
                }
            }

            return Text;
        }
        set
        {
            if (UseTranslation)
            {
                Translations[key] = value;
            }
            else
            {
                Text = value;
            }
        }
    }

    public LocalizedTextRequest()
    {
        Text = string.Empty;
        Translations = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
    }

    public static implicit operator LocalizedTextRequest(string text)
    {        
        return new LocalizedTextRequest { Text = text, UseTranslation = false };
    }

    public static implicit operator LocalizedTextRequest(Dictionary<string, string> translations)
    {
        return new (translations);
    }

    public LocalizedTextRequest(IDictionary<string, string> translations)
    {
        Text = string.Empty;
        Translations = translations;
        UseTranslation = true;
    }

    public LocalizedTextRequest(string text)
    {
        Text = text;
        Translations = new Dictionary<string, string>();
    }
}

public class LocalizedTextResponse : ILocalizedText
{
    public string Text { get; set; } = null!;
    public bool UseTranslation { get; set; }
    public IDictionary<string, string> Translations { get; set; } = null!;

    public string this[string key]
    {
        get
        {
            if (UseTranslation)
            {
                if (Translations.TryGetValue(key, out var value))
                {
                    return value;
                }
            }

            return Text;
        }
        set
        {
            if (UseTranslation)
            {
                Translations[key] = value;
            }
            else
            {
                Text = value;
            }
        }
    }

    public static implicit operator LocalizedTextResponse(string text)
    {
        return new LocalizedTextResponse { Text = text, UseTranslation = false };
    }
}

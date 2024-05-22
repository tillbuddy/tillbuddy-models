using System.Net.NetworkInformation;
using System.Numerics;

namespace TillBuddy.Models;

public interface ILocalizedText : ICloneable
{
    public string Text { get; set; }
    public bool UseTranslation { get; set; }
    public IDictionary<string, string> Translations { get; set; }
    public string this[string key] { get;set; }

}

public class LocalizedText : ILocalizedText
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

    public LocalizedText(ILocalizedText localizedText)
    {
        Text = localizedText.Text;
        UseTranslation = localizedText.UseTranslation;
        Translations = localizedText.Translations.Clone();
    }

    public LocalizedText()
    {
        Text = string.Empty;
        Translations = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
    }

    public static implicit operator LocalizedText(string text)
    {
        return new LocalizedTextRequest { Text = text, UseTranslation = false };
    }

    public static implicit operator LocalizedText(Dictionary<string, string> translations)
    {
        return new(translations);
    }

    public LocalizedText(IDictionary<string, string> translations)
    {
        Text = string.Empty;
        Translations = translations;
        UseTranslation = true;
    }

    public LocalizedText(string text)
    {
        Text = text;
        Translations = new Dictionary<string, string>();
    }

    public virtual object Clone()
    {
        return new LocalizedText()
        {
            Text = Text,
            UseTranslation = UseTranslation,
            Translations = Translations.Clone()
        };
    }

    public LocalizedTextResponse MapToResponse()
    {
        return new()
        {
            Text = Text,
            UseTranslation = UseTranslation,
            Translations = Translations.Clone()
        };
    }

    public LocalizedTextRequest MapToRequest()
    {
        return new()
        {
            Text = Text,
            UseTranslation = UseTranslation,
            Translations = Translations.Clone()
        };
    }
}

public class LocalizedTextRequest : LocalizedText
{
    public LocalizedTextRequest() { }

    public LocalizedTextRequest(IDictionary<string, string> translations) : base(translations) { }

    public LocalizedTextRequest(string text) : base(text) { }

    public static implicit operator LocalizedTextRequest(string text)
    {        
        return new LocalizedTextRequest { Text = text, UseTranslation = false };
    }

    public static implicit operator LocalizedTextRequest(Dictionary<string, string> translations)
    {
        return new (translations);
    }

    public override object Clone()
    {
        return new LocalizedTextRequest()
        {
            Text = Text,
            UseTranslation = UseTranslation,
            Translations = Translations.Clone()
        };
    }
}

public class LocalizedTextResponse : LocalizedText
{
    public LocalizedTextResponse() { }

    public LocalizedTextResponse(IDictionary<string, string> translations) : base(translations) { }

    public LocalizedTextResponse(string text) : base(text) { }

    public static implicit operator LocalizedTextResponse(string text)
    {
        return new LocalizedTextResponse { Text = text, UseTranslation = false };
    }

    public static implicit operator LocalizedTextResponse(Dictionary<string, string> translations)
    {
        return new (translations);
    }

    public override object Clone()
    {
        return new LocalizedTextResponse()
        {
            Text = Text,
            UseTranslation = UseTranslation,
            Translations = Translations.Clone()
        };
    }
}

using Dawn;
using System.Text.Json.Serialization;
using TillBuddy.Models.Converters;

namespace TillBuddy.SDK.Model;

[JsonConverter(typeof(JsonLocalizedTextConverter))]
public class LocalizedText : ICloneable
{
    public string Text { get; set; }
    public bool UseTranslation { get; set; }
    public IDictionary<string, string> Translations { get; private set; }

    public LocalizedText(string text)
    {
        Guard.Argument(() => text).NotNull();
        
        Text = text;
        Translations = new Dictionary<string, string>();
    }

    public LocalizedText(IDictionary<string, string> translations)
    {
        Guard.Argument(() => translations).NotNull();
        
        Text = string.Empty;
        Translations = Clone(translations);
        UseTranslation = true;
    }

    public LocalizedText()
    {
        Text = string.Empty;
        Translations = CreateTranslationDictionary();
    }

    /// <summary>
    /// Find the translation for the given key
    /// 
    /// If translation is not found, the default text is returned
    /// </summary>
    /// <param name="language">Language (ISO)</param>
    /// <returns></returns>
    public string this[string language]
    {
        get
        {
            if (!UseTranslation) return Text;

            if (Translations.TryGetValue(language, out var value))
            {
                return value;
            }

            // Fallback to the default text if no translation is not found
            return Text;
        }
        set
        {
            if (UseTranslation)
            {
                Translations[language] = value;
            }
            else
            {
                 Text = value;
            }
        }
    }

    public static LocalizedText Parse(string text)
    {
        Guard.Argument(() => text).NotNull();

        return new(text);
    }

    public static LocalizedText Parse(IDictionary<string, string> translations)
    {
        return new LocalizedText(translations);
    }

    private static Dictionary<string, string> CreateTranslationDictionary()
    {
        return new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
    }

    public LocalizedText Populate(LocalizedText source)
    {
        Text = source.Text;
        Translations = Clone(source.Translations);
        UseTranslation = source.UseTranslation;

        return this;
    }

    private static Dictionary<string, string> Clone(IDictionary<string, string> source)
    {
        var d = CreateTranslationDictionary();
        
        foreach (var (key, value) in source)
        {
            d[key] = value;
        }

        return d;
    }

    public object Clone()
    {
        var clone = new LocalizedText
        {
            Text = Text,
            UseTranslation = UseTranslation
        };

        if (Translations != null)
        {
            clone.Translations = Clone(Translations);
        }

        return clone;
    }

    public static implicit operator LocalizedText(string text)
    {
        return new LocalizedText { Text = text, UseTranslation = false };
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;

        if (obj is LocalizedText other)
        {
            return Text == other.Text &&
                   UseTranslation == other.UseTranslation &&
                   DictionariesEqual(Translations, other.Translations);
        }
        return false;
    }

    public override int GetHashCode()
    {
        int hash = Text?.GetHashCode() ?? 0;
        hash = (hash * 31) + UseTranslation.GetHashCode();
        if (Translations != null)
        {
            foreach (var kvp in Translations)
            {
                hash = (hash * 31) + kvp.Key.GetHashCode();
                hash = (hash * 31) + kvp.Value.GetHashCode();
            }
        }
        return hash;
    }

    private bool DictionariesEqual(IDictionary<string, string> dict1, IDictionary<string, string> dict2)
    {
        if (dict1 == dict2)
        {
            return true;
        }
        if (dict1 == null || dict2 == null || dict1.Count != dict2.Count)
        {
            return false;
        }
        foreach (var kvp in dict1)
        {
            if (!dict2.TryGetValue(kvp.Key, out var value) || kvp.Value != value)
            {
                return false;
            }
        }
        return true;
    }

    public static implicit operator string(LocalizedText? localizedText)
    {
#pragma warning disable CS8603 // Suppress "Possible null reference return"
        return localizedText?.Text;
#pragma warning restore CS8603
    }

    public override string ToString()
    {
        return "";
    }
}


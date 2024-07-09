using Dawn;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TillBuddy.SDK.Model;

[JsonConverter(typeof(LocalizedTextJsonConverter))]
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

    public string this[string key]
    {
        get
        {
            if(UseTranslation)
            {
                if(Translations.TryGetValue(key, out var value))
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

    public static implicit operator string(LocalizedText localizedText)
    {
        return localizedText.Text;
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

    public static bool operator ==(LocalizedText lhs, LocalizedText rhs)
    {
        if (ReferenceEquals(lhs, rhs))
        {
            return true;
        }
        if (lhs is null || rhs is null)
        {
            return false;
        }
        return lhs.Equals(rhs);
    }

    public static bool operator !=(LocalizedText lhs, LocalizedText rhs)
    {
        return !(lhs == rhs);
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
}

public class LocalizedTextJsonConverter : JsonConverter<LocalizedText>
{
    public override LocalizedText Read(
        ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("Expected StartObject token.");
        }

        var localizedText = new LocalizedText();
        bool hasUseTranslationAttribute = false;

        while (reader.Read())
        {
            // End of object
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                // Validate if UseTranslation is not set, set it to true if translations are present
                if (!hasUseTranslationAttribute)
                {
                    localizedText.UseTranslation = localizedText.Translations.Count > 0;
                }

                return localizedText;
            }

            var propertyName = ReadPropertyName(ref reader);

            reader.Read();

            switch (propertyName)
            {
                case "text":
                    localizedText.Text = ParseText(ref reader);                    
                    break;
                case "usetranslation":
                    hasUseTranslationAttribute = true;
                    localizedText.UseTranslation = reader.GetBoolean();
                    break;
                case "translations":
                    ParseTranslations(ref reader, options, localizedText.Translations);
                    break;
                default:
                    throw new JsonException($"Property {propertyName} is not supported.");
            }
        }

        throw new JsonException("Expected an EndObject token.");
    }

    /// <summary>
    /// Read translations from json and insert into existing translations dictionary
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="options"></param>
    /// <param name="translations"></param>
    private void ParseTranslations(ref Utf8JsonReader reader, JsonSerializerOptions options, IDictionary<string, string> translations)
    {
        var t = JsonSerializer.Deserialize<IDictionary<string, string>>(ref reader, options);
        if (t != null)
        {
            foreach (var translation in t)
            {
                translations[translation.Key] = translation.Value;
            }
        }
    }

    private string ParseText(ref Utf8JsonReader reader)
    {
        return reader.GetString() ?? string.Empty;
    }

    private string ReadPropertyName(ref Utf8JsonReader reader)
    {
        // Ensure the current token is a property name.
        if (reader.TokenType != JsonTokenType.PropertyName)
        {
            throw new JsonException("Expected a property name.");
        }

        string propertyName = reader.GetString()?.ToLower() ?? string.Empty;

        if (string.IsNullOrEmpty(propertyName))
            throw new JsonException($"Empty property name is not supported.");

        return propertyName;
    }

    public override void Write(
        Utf8JsonWriter writer,
        LocalizedText localizedText,
        JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WriteString("text", localizedText.Text);
        writer.WriteBoolean("useTranslation", localizedText.UseTranslation);

        writer.WritePropertyName("translations");
        JsonSerializer.Serialize(writer, localizedText.Translations, options);

        writer.WriteEndObject();
    }
}


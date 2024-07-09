using System.Text.Json;
using System.Text.Json.Serialization;
using TillBuddy.SDK.Model;

namespace TillBuddy.Models.Converters;

public class JsonLocalizedTextConverter : JsonConverter<LocalizedText>
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


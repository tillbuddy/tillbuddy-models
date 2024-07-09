using System.Text.Json;
using System.Text.Json.Serialization;
using TillBuddy.SDK.Model;

namespace TillBuddy.Models.Converters;

public class JsonCurrencyConverter : JsonConverter<Currency>
{
    public override Currency Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        // We support both Currency: "NOK" and { value: "NOK" }
        if (reader.TokenType == JsonTokenType.String)
        {
            return Currency.Parse(reader.GetString());
        }

        Currency value = new();

        while (reader.Read())
        {

            if (reader.TokenType == JsonTokenType.PropertyName && string.Compare(reader.GetString(), "value", true) == 0)
            {
                reader.Read();

                if (reader.TokenType != JsonTokenType.String)
                    throw new JsonException("Expected string value. Ref Currency: { \"value\": \"NOK\" }");

                value = Currency.Parse(reader.GetString());
            }

            if (reader.TokenType == JsonTokenType.EndObject)
                return value;
        }

        throw new JsonException("Expected Currency: { \"value\": \"NOK\" }");
    }

    public override void Write(
        Utf8JsonWriter writer,
        Currency value,
        JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TillBuddy.Models.Converters;

// without this class serialization was:    2023-06-20T10:20:14
// now result is:                           2023-06-20T10:20:14.000000Z
public class JsonDateTimeConverter : JsonConverter<DateTime>
{
    public const string OutputFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.ffffff'Z'";

    public override DateTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        // we left default behaviour
        return JsonSerializer.Deserialize<DateTime>(ref reader);
    }

    public override void Write(
        Utf8JsonWriter writer,
        DateTime value,
        JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(OutputFormat, CultureInfo.InvariantCulture));
    }
}

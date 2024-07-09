using System.Text.Json;
using System.Text.Json.Serialization;
using TillBuddy.Models.Converters;

namespace TillBuddy.SDK.Converters;

public static partial class JsonConvertersExtensions
{
    public static JsonSerializerOptions AddTillBuddyJsonOptions(this JsonSerializerOptions options)
    {
        options.PropertyNameCaseInsensitive = true;

        options.Converters.Add(new JsonStringEnumConverter());
        options.Converters.Add(new JsonCurrencyConverter());
        options.Converters.Add(new JsonDateTimeConverter());

        return options;
    }
}

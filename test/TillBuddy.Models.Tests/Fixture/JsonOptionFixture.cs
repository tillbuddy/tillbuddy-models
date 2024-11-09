using System.Text.Json;
using TillBuddy.Models.Converters;

namespace TillBuddy.Models.Tests.Fixture;

[CollectionDefinition("JsonOption")]
public class JsonOptionFixture
{
    public JsonSerializerOptions JsonOptions { get; set; }

    public JsonOptionFixture()
    {
        JsonOptions = new JsonSerializerOptions()
            .AddTillBuddyJsonOptions();
    }
}

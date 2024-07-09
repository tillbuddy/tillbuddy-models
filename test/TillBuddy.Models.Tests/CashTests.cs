using FluentAssertions;
using Newtonsoft.Json;
using System.Globalization;

namespace TillBuddy.Models.Tests;

public class CashTests
{
    public static IEnumerable<object[]> ValidJson()
    {
        return new TheoryData<string>
        {
            """
            {
                "amount": 
                { 
                    "amount": 10, 
                    "currency": "NOK" 
                },
                "userId": "7cf8f7ea-f7cc-4800-8ccc-6ee868781e35",
                "registeredAt": "2022-01-04T11:02:37.861Z"
            }
            """,
            """
            {
                "amount": 
                { 
                    "amount": 10, 
                    "currency": "NOK" 
                },
                "userId": "7cf8f7ea-f7cc-4800-8ccc-6ee868781e35",
                "registeredAt": "2022-01-04T11:02:37.861+00:00"
            }
            """
        };
    }

    [Theory, MemberData(nameof(ValidJson))]
    public void Parse_userId_from_json(string value)
    {
        var actual = JsonConvert.DeserializeObject<Cash>(value);

        actual.UserId.Should().Be("7cf8f7ea-f7cc-4800-8ccc-6ee868781e35");
    }

    [Theory, MemberData(nameof(ValidJson))]
    public void Parse_registeredAt_from_json(string value)
    {
        var actual = JsonConvert.DeserializeObject<Cash>(value, new JsonSerializerSettings
        {
            DateTimeZoneHandling = DateTimeZoneHandling.Utc
        });

        var date = DateTime.ParseExact(
            "2022-01-04T11:02:37.861Z",
            "yyyy-MM-ddTHH:mm:ss.fffZ",
            CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);

        Console.WriteLine(date.Kind);

        actual.RegisteredAt.Should().Be(date);
    }
}

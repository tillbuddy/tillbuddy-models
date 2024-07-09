using FluentAssertions;
using System.Text.Json;
using TillBuddy.SDK.Model;

namespace TillBuddy.Models.Tests;

public class CashTests
{
    public static IEnumerable<object[]> ValidJson()
    {
        return new TheoryData<string>
        {
            """
            {
                "Amount": 
                { 
                    "Amount": 10, 
                    "Currency": "NOK" 
                },
                "UserId": "7cf8f7ea-f7cc-4800-8ccc-6ee868781e35",
                "RegisteredAt": "2022-01-04T11:02:37.861Z"
            }
            """,
            """
            {
                "Amount": 
                { 
                    "Amount": 10, 
                    "Currency": "NOK" 
                },
                "UserId": "7cf8f7ea-f7cc-4800-8ccc-6ee868781e35",
                "RegisteredAt": "2022-01-04T11:02:37.861+00:00"
            }
            """
        };
    }



    [Theory, MemberData(nameof(ValidJson))]
    public void Parse_amount_from_json(string value)
    {
        JsonSerializer.Deserialize<Cash>(value);

        var actual = JsonSerializer.Deserialize<Cash>(value);

        actual.Amount.Amount.Should().Be(10);
    }

    [Theory, MemberData(nameof(ValidJson))]
    public void Parse_currency_from_json(string value)
    {
        var actual = JsonSerializer.Deserialize<Cash>(value);

        actual.Amount.Currency.Value.Should().Be("NOK");
    }

}

using FluentAssertions;
using System.Text.Json;
using TillBuddy.Models.Tests.Fixture;
using TillBuddy.Models;
using TillBuddy.Models.Exceptions;

namespace TillBuddy.Models.Tests;

public class MoneyTests : IClassFixture<JsonOptionFixture>
{
    public static TheoryData<string?> InvalidCtorValues()
    {
        return new TheoryData<string?>
        {
            null,
            "",
            "NOK",
            "25",
            "25 DOLLAR",
        };
    }

    public static IEnumerable<object[]> ValidCtorValues()
    {
        return new TheoryData<string>
        {
            "25,0 NOK",
            "25.0 NOK",
            "25 NOK",
        };
    }

    public static IEnumerable<object[]> JsonValue()
    {
        return new TheoryData<string>
        {
            @" { ""Amount"": 25, ""Currency"": ""NOK"" }",
            @" { ""Amount"": 25.0, ""Currency"": ""NOK"" }"
        };
    }

    [Theory, MemberData(nameof(InvalidCtorValues))]
    public void TryParse_returns_false_when_an_invalid_argument_is_specified(string value)
    {
        var actual = Money.TryParse(value, out _);

        actual.Should().BeFalse();
    }

    [Theory, MemberData(nameof(ValidCtorValues))]
    public void TryParse_returns_true_when_a_valid_argument_is_specified(string value)
    {
        var actual = Money.TryParse(value, out _);

        actual.Should().BeTrue();
    }

    [Theory, MemberData(nameof(InvalidCtorValues))]
    public void Parse_throws_when_invalid_arguments_are_specified(string value)
    {
        Action act = () => Money.Parse(value);

        act.Should().Throw<MoneyArgumentFormatException>();
    }

    [Theory, MemberData(nameof(ValidCtorValues))]
    public void Parse_does_not_throw_when_valid_arguments_are_specified(string value)
    {
        Action act = () => Money.Parse(value);

        act.Should().NotThrow();
    }

    [Theory, MemberData(nameof(ValidCtorValues))]
    public void ToString_returns_formatted_value_than_can_be_parsed_again(string value)
    {
        var sut = Money.Parse(value);

        Func<Money> act = () => Money.Parse(sut.ToString());

        act.Should().NotThrow()
           .And.Subject.Invoke().Should().BeEquivalentTo(sut);
    }

    [Theory, MemberData(nameof(ValidCtorValues))]
    public void The_implicit_conversion_to_string_is_equivalent_to_ToString(string value)
    {
        var sut = Money.Parse(value);

        string actual = sut.ToString();

        actual.Should().BeEquivalentTo(sut.ToString());
    }

    [Fact]
    public void HasSameCurrency_is_true_for_same()
    {
        var mon1 = Money.Parse("10.00 NOK");
        var mon2 = Money.Parse("20.00 NOK");

        bool sameCurrency = mon1.HasSameCurrency(mon2);

        sameCurrency.Should().Be(true);
    }

    [Fact]
    public void HasSameCurrency_is_false_for_different()
    {
        var mon1 = Money.Parse("10.00 NOK");
        var mon2 = Money.Parse("20.00 PLN");

        bool sameCurrency = mon1.HasSameCurrency(mon2);

        sameCurrency.Should().Be(false);
    }
    [Fact]
    public void Add_should_works_for_valid()
    {
        var mon1 = Money.Parse("10.00 NOK");
        var mon2 = Money.Parse("20.00 NOK");

        mon1.Add(mon2);

        mon1.Amount.Should().Be(30);
    }

    [Fact]
    public void AddRange_should_works_for_valid()
    {
        var mon1 = Money.Parse("10.00 NOK");

        var mon2 = new List<Money>
        {
            Money.Parse("10.00 NOK"),
            Money.Parse("20.00 NOK"),
            Money.Parse("10.00 NOK")
        };

        mon1.AddRange(mon2);

        mon1.Amount.Should().Be(50);
    }

    [Theory, MemberData(nameof(JsonValue))]
    public void Parse_amount_from_json(string value)
    {
        var actual = JsonSerializer.Deserialize<Money>(value);

        actual.Should().NotBeNull();

        actual?.Amount.Should().Be(25);
    }

    [Theory, MemberData(nameof(JsonValue))]
    public void Parse_currency_from_json(string value)
    {
        var actual = JsonSerializer.Deserialize<Money>(value);

        actual.Should().NotBeNull();

        actual?.Currency.Value.Should().Be("NOK");
    }
}

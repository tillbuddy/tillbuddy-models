using FluentAssertions;
using TillBuddy.Models;
using TillBuddy.Models.Exceptions;

namespace TillBuddy.Models.Tests;

public class PercentTests
{
    public static TheoryData<string> InvalidCtorValues()
    {
        return new TheoryData<string>
        {
            null,
            "-25",
            "25",
            "%25",
        };
    }

    public static IEnumerable<object[]> ValidCtorValues()
    {
        return new TheoryData<string>
        {
            "25,0%",
            "25%",
            "2,000.40%",
            "-25%",
            "25.%",
            "0.12%",
            "0,12%",
        };
    }

    [Theory, MemberData(nameof(InvalidCtorValues))]
    public void TryParse_returns_false_when_an_invalid_argument_is_specified(string value)
    {
        var actual = Percent.TryParse(value, out _);

        actual.Should().BeFalse();
    }

    [Theory, MemberData(nameof(ValidCtorValues))]
    public void TryParse_returns_true_when_a_valid_argument_is_specified(string value)
    {
        var actual = Percent.TryParse(value, out _);

        actual.Should().BeTrue();
    }

    [Theory, MemberData(nameof(InvalidCtorValues))]
    public void Parse_throws_when_invalid_arguments_are_specified(string value)
    {
        Action act = () => Percent.Parse(value);

        act.Should().Throw<PercentArgumentFormatException>();
    }

    [Theory, MemberData(nameof(ValidCtorValues))]
    public void Parse_does_not_throw_when_valid_arguments_are_specified(string value)
    {
        Action act = () => Percent.Parse(value);

        act.Should().NotThrow();
    }

    [Theory, MemberData(nameof(ValidCtorValues))]
    public void ToString_returns_formatted_value_than_can_be_parsed_again(string value)
    {
        var sut = Percent.Parse(value);

        Func<Percent> act = () => Percent.Parse(sut.ToString());

        act.Should().NotThrow()
           .And.Subject.Invoke().Should().BeEquivalentTo(sut);
    }

    [Theory, MemberData(nameof(ValidCtorValues))]
    public void The_implicit_conversion_to_string_is_equivalent_to_ToString(string value)
    {
        var sut = Percent.Parse(value);

        string actual = sut.ToString();

        actual.Should().BeEquivalentTo(sut.ToString());
    }
}
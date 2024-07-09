using FluentAssertions;
using Newtonsoft.Json.Linq;
using TillBuddy.SDK.Model;
using TillBuddy.SDK.Model.Exceptions;

namespace TillBuddy.Models.Tests;

public class CoordinatesTests
{
    public static TheoryData<string> InvalidCtorValues()
    {
        return new TheoryData<string>
        {
            "1.23,2210.1221",  // incorrect check digit
            "200.0,300.0", // to long
        };
    }

    public static TheoryData<string> ValidCtorValues()
    {
        return new TheoryData<string>
        {
            "90,180",
            "-90,-180",
            "4.223,-2.123",
        };
    }

    [Theory, MemberData(nameof(InvalidCtorValues))]
    public void TryParse_returns_false_when_an_invalid_argument_is_specified(string value)
    {
        var actual = Coordinates.TryParse(value, out _);

        actual.Should().BeFalse();
    }

    [Theory, MemberData(nameof(ValidCtorValues))]
    public void TryParse_returns_true_when_a_valid_argument_is_specified(string value)
    {
        var actual = Coordinates.TryParse(value, out _);

        actual.Should().BeTrue();
    }


    [Theory, MemberData(nameof(InvalidCtorValues))]
    public void Parse_throws_when_invalid_arguments_are_specified(string value)
    {
        Action act = () => Coordinates.Parse(value);

        act.Should().Throw<CoordinatesArgumentFormatException>();
    }

    [Theory, MemberData(nameof(ValidCtorValues))]
    public void Parse_does_not_throw_when_valid_arguments_are_specified(string value)
    {
        Action act = () => Coordinates.Parse(value);

        act.Should().NotThrow();
    }

    [Theory, MemberData(nameof(ValidCtorValues))]
    public void ToString_returns_formatted_value_than_can_be_parsed_again(string value)
    {
        var sut = Coordinates.Parse(value);

        Func<Coordinates> act = () => Coordinates.Parse(sut.ToString());

        act.Should().NotThrow()
           .And.Subject.Invoke().Should().BeEquivalentTo(sut);
    }

    [Fact]
    public void Empty_coordinate_should_be_0_0()
    {
        var coordinate = new Coordinates();

        coordinate.ToString().Should().Be("0,0");
    }
}

using FluentAssertions;
using TillBuddy.Models;

namespace TillBuddy.Models.Tests;

public class MobilePhoneTests
{
    [Theory]
    [InlineData("+10123456789")]
    public void Valid_phone_should_parse(string value)
    {
        var result = MobilePhone.Parse(value);

        result.ToString().Should().Be(value);
    }
}

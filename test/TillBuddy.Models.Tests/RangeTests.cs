using FluentAssertions;
using TillBuddy.Models;

namespace TillBuddy.Models.Tests;

public class RangeTests
{
    [Fact]
    public void Range_of_int_should_work()
    {
        var r = new FromTo<int>(1, 10);

        r.From.Should().Be(1);
        r.To.Should().Be(10);
    }

    [Fact]
    public void Range_of_date_should_work()
    {
        var from = DateTime.Now.AddMonths(-1);
        var to = DateTime.Now;

        var r = new FromTo<DateTime>(from, to);

        r.From.Should().Be(from);
        r.To.Should().Be(to);
    }
}

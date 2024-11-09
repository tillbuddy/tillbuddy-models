using FluentAssertions;
using System.Reflection;
using TillBuddy.Models;

namespace TillBuddy.Models.Tests;

public class PairTests
{
    [Fact]
    public void Int_should_work()
    {
        var r = new GenericPair<int, int>(1, 10);

        r.Id.Should().Be(1);
        r.Name.Should().Be(10);
    }

    [Fact]
    public void Mix_of_types_should_work()
    {
        var r = new GenericPair<int, string>(100, "Red");

        r.Id.Should().Be(100);
        r.Name.Should().Be("Red");
    }

    [Fact]
    public void Parse_should_work_without_specifying_type()
    {
        var b = new Pair("a", "b");

        b.Id.Should().Be("a");
        b.Name.Should().Be("b");
    }
}

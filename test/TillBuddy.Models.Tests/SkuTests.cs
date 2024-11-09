using FluentAssertions;
using TillBuddy.Models;

namespace TillBuddy.Models.Tests;

public class SkuTests
{
    [Fact]
    public void Sku_should_work()
    {
        var s = Guid.NewGuid().ToString();

        var actual = Sku.Parse(s);

        actual.Should().NotBeNull();
    }

    [Fact]
    public void Sku_should_be_equal()
    {
        var s = Guid.NewGuid().ToString();

        var actual = Sku.Parse(s);

        actual.ToString().Should().BeEquivalentTo(s);
    }

    [Fact]
    public void Sku_as_string_should_be_equal()
    {
        var s = Guid.NewGuid().ToString();

        var sku = Sku.Parse(s);

        string actual = sku;

        actual.Should().BeEquivalentTo(s);
    }
}

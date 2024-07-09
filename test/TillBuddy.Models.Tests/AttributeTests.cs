namespace TillBuddy.Models.Tests;

public class AttributeTests
{
    [Fact]
    public void DefaultConstructor_InitializesPropertiesCorrectly()
    {
        var attribute = new Attribute();

        Assert.Equal("", attribute.AttributeId);
        Assert.Equal("", attribute.DisplayName);
        Assert.Equal("", attribute.Value);
        Assert.Equal(DataType.Text, attribute.DataType);
        Assert.Null(attribute.LocalizedValue);
        Assert.Null(attribute.Decimal);
        Assert.Null(attribute.Bool);
        Assert.Null(attribute.LocalizedValue);
        Assert.Null(attribute.LocalizedValues);
    }

    [Fact]
    public void ParameterizedConstructor_InitializesPropertiesCorrectly()
    {
        var groupId = "G1";
        var groupName = "Group Name";
        var attributeId = "A1";
        var displayName = "Attribute Name";

        var value = "Test Value";

        var attribute = new Attribute(
            attributeId,
            displayName, 
            value);

        Assert.Equal(displayName, attribute.DisplayName);
        Assert.Equal(value, attribute.Value);
        Assert.Equal(DataType.Text, attribute.DataType);
    }

    [Fact]
    public void ParameterizedConstructor_ThrowsException_WhenDisplayNameIsNull()
    {
        var value = "Test Value";

        var exception = Assert.Throws<ArgumentNullException>(() => new Attribute(
            "", 
            null, 
            value));

        Assert.Equal("displayName", exception.ParamName);
    }

    [Fact]
    public void ParameterizedConstructor_ThrowsException_WhenDisplayNameIsEmpty()
    {
        var value = "Test Value";

        var exception = Assert.Throws<ArgumentException>(() => new Attribute(
            "",
            "",
            value));

        Assert.Equal("displayName", exception.ParamName);
    }

    [Fact]
    public void ParameterizedConstructor_ThrowsException_WhenValueIsNull()
    {
        var displayName = "Test Name";

        var exception = Assert.Throws<ArgumentNullException>(() => new Attribute(
            "", 
            displayName, 
            null));

        Assert.Equal("value", exception.ParamName);
    }
}

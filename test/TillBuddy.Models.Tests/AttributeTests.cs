using TillBuddy.SDK.Model;

namespace TillBuddy.Models.Tests;

public class AttributeTests
{
    [Fact]
    public void DefaultConstructor_InitializesPropertiesCorrectly()
    {
        var attribute = new TillBuddy.SDK.Model.Attribute();

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

        var attribute = new SDK.Model.Attribute(
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

        var exception = Assert.Throws<ArgumentNullException>(() => new SDK.Model.Attribute(
            "", 
            null, 
            value));

        Assert.Equal("displayName", exception.ParamName);
    }

    [Fact]
    public void ParameterizedConstructor_ThrowsException_WhenDisplayNameIsEmpty()
    {
        var value = "Test Value";

        var exception = Assert.Throws<ArgumentException>(() => new SDK.Model.Attribute(
            "",
            "",
            value));

        Assert.Equal("displayName", exception.ParamName);
    }

    [Fact]
    public void ParameterizedConstructor_ThrowsException_WhenValueIsNull()
    {
        var displayName = "Test Name";

        var exception = Assert.Throws<ArgumentNullException>(() => new SDK.Model.Attribute(
            "", 
            displayName, 
            null));

        Assert.Equal("value", exception.ParamName);
    }

    [Fact]
    public void SerializeObject_ExcludesNullProperties_UsingSystemTextJson()
    {
        // Create an instance of Attribute with some properties set to null
        var attribute = new SDK.Model.Attribute(
            "A1",
            "Attribute Name",
            "Test Value")
        {
            LocalizedValue = null,
            Integer = null,
            Decimal = null,
            Bool = null,
            DateTime = null,
            Values = null,
            LocalizedValues = null
        };

        // Serialize the object to JSON
        var json = System.Text.Json.JsonSerializer.Serialize(attribute);

        // Assert that the JSON does not contain the null properties
        Assert.DoesNotContain("\"LocalizedValue\":", json);
        Assert.DoesNotContain("\"Integer\":", json);
        Assert.DoesNotContain("\"Decimal\":", json);
        Assert.DoesNotContain("\"Bool\":", json);
        Assert.DoesNotContain("\"DateTime\":", json);
        Assert.DoesNotContain("\"Values\":", json);
        Assert.DoesNotContain("\"LocalizedValues\":", json);

        Assert.Contains("\"DisplayName\":", json);
        Assert.Contains("\"Value\":", json);
    }
}

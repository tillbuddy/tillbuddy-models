using Dawn;
using System.Text.Json.Serialization;

namespace TillBuddy.SDK.Model;

public class Attribute : ICloneable
{
    public Attribute()
    {
        AttributeId = "";
        DisplayName = "";

        Value = "";
        DataType = DataType.Text;
    }

    public Attribute(
        string attributeId,
        string displayName, 
        string value)
    {
        Guard.Argument(() => attributeId).NotNull();
        Guard.Argument(() => displayName).NotNull().NotEmpty();

        Guard.Argument(() => value).NotNull();

        AttributeId = attributeId;
        DisplayName = displayName;

        Value = value;
        DataType = DataType.Text;
    }

    public string AttributeId { get; set; }
    public string DisplayName { get; set; }

    public string Value { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DataType DataType { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LocalizedText? LocalizedValue { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Integer { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public decimal? Decimal { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Bool { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? DateTime { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string>? Values { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<LocalizedText>? LocalizedValues { get; set; }

    public object Clone()
    {
        return new Attribute
        {
            AttributeId = AttributeId,
            Bool = Bool,
            DataType = DataType,
            DateTime = DateTime,
            Decimal = Decimal,
            DisplayName = DisplayName,
            Integer = Integer,
            LocalizedValue = (LocalizedText?) LocalizedValue?.Clone(),
            LocalizedValues = LocalizedValues == null ? null : LocalizedValues.Select(x => (LocalizedText) x.Clone()),
            Value = Value,
            Values = Values == null ? null : new List<string>(Values)
        };
    }
}


public class AttributeResponse
{

    public string AttributeId { get; set; } = null!;
    public string DisplayName { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string DataType { get; set; } = null!;

    public LocalizedText? LocalizedValue { get; set; }

    public int? Integer { get; set; }

    public decimal? Decimal { get; set; }

    public bool? Bool { get; set; }

    public DateTime? DateTime { get; set; }

    public IEnumerable<string>? Values { get; set; }

    public IEnumerable<LocalizedText>? LocalizedValues { get; set; }
}

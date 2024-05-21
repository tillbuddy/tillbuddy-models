#nullable enable
using System.Text.Json.Serialization;

namespace TillBuddy.Models;

public interface IAttribute : ICloneable
{
    public string AttributeId { get; set; }
    public string DisplayName { get; set; }
    public string Value { get; set; }

    public DataType DataType { get; set; }
    public ILocalizedText? LocalizedValue { get; set; }
    public int? Integer { get; set; }
    public decimal? Decimal { get; set; }
    public bool? Bool { get; set; }
    public DateTime? DateTime { get; set; }
    public IEnumerable<string>? Values { get; set; }
    public IEnumerable<ILocalizedText>? LocalizedValues { get; set; }
}

public class Attribute : IAttribute
{
    public string AttributeId { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public string Value { get; set; } = null!;

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
        if(string.IsNullOrEmpty(attributeId)) throw new ArgumentNullException(nameof(attributeId));
        if(string.IsNullOrEmpty(displayName)) throw new ArgumentNullException(nameof(displayName));
        if(value == null) throw new ArgumentNullException(nameof(value));

        AttributeId = attributeId;
        DisplayName = displayName;

        Value = value;
        DataType = DataType.Text;
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DataType DataType { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ILocalizedText? LocalizedValue { get; set; }

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
    public IEnumerable<ILocalizedText>? LocalizedValues { get; set; }

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
            LocalizedValue = (LocalizedText?)LocalizedValue?.Clone(),
            LocalizedValues = LocalizedValues == null ? null : LocalizedValues.Select(x => (LocalizedText)x.Clone()),
            Value = Value,
            Values = Values == null ? null : new List<string>(Values)
        };
    }
}

public class AttributeRequest : Attribute
{
}

public class AttributeResponse : Attribute
{
}

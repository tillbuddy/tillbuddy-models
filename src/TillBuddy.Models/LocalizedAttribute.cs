using System.Text.Json.Serialization;

namespace TillBuddy.Models;

public interface ILocalizedAttribute
{
    public string AttributeId { get; set; }
    public string DisplayName { get; set; }
    public string Value { get; set; }

    public DataType DataType { get; set; }
    public LocalizedText? LocalizedValue { get; set; }
    public int? Integer { get; set; }
    public decimal? Decimal { get; set; }
    public bool? Bool { get; set; }
    public DateTime? DateTime { get; set; }
    public IEnumerable<string>? Values { get; set; }
    public IEnumerable<LocalizedText>? LocalizedValues { get; set; }
}

public class LocalizedAttribute : IAttribute
{
    public string AttributeId { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public string Value { get; set; } = null!;
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
        return new LocalizedAttribute()
        {
            AttributeId = AttributeId,
            Bool = Bool,
            DataType = DataType,
            DateTime = DateTime,
            Decimal = Decimal,
            DisplayName = DisplayName,
            Integer = Integer,
            LocalizedValue = (LocalizedText?) LocalizedValue?.Clone(),
            LocalizedValues = Clone(LocalizedValues),
            Value = Value,
            Values = Values?.ToList()
        };
    }

    private static List<LocalizedText>? Clone(IEnumerable<ILocalizedText>? localizedTexts)
    {
        if (localizedTexts == null) return null;

        var result = new List<LocalizedText>();

        foreach (var localizedText in localizedTexts)
        {
            result.Add((LocalizedText) localizedText.Clone());
        }

        return result;
    }
}

public class LocalizedAttributeRequest : LocalizedAttribute
{   
}

public class LocalizedAttributeResponse : LocalizedAttribute
{   
}

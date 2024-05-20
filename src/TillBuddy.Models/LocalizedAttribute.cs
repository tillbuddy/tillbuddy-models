using System.Text.Json.Serialization;

namespace TillBuddy.Models;

public interface ILocalizedAttribute
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

public class LocalizedAttribute : IAttribute
{
    public string AttributeId { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public string Value { get; set; } = null!;

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
}

public class LocalizedAttributeRequest : LocalizedAttribute
{   
}

public class LocalizedAttributeResponse : LocalizedAttribute
{   
}

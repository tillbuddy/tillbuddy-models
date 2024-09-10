using System.Text.Json.Serialization;

namespace TillBuddy.SDK.Model;

[JsonConverter(typeof(JsonStringEnumConverter<DataType>))]
public enum DataType
{
    Text,
    LocalizedText,
    Integer,
    DateTime,
    Decimal,
    Bool,
    List,
    LocalizedList,
    Asset,
    Json,
    Xml,
    Url
}

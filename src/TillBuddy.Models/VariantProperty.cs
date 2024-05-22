namespace TillBuddy.Models;

public interface IVariantProperty : ICloneable
{
    public string Name { get; set; }
    public string Value { get; set; }
}

public class VariantProperty : IVariantProperty
{
    public string Name { get; set; } = null!;
    public string Value { get; set; } = null!;

    public VariantProperty() { }

    public VariantProperty(string name, string value)
    {
        Name = name;
        Value = value;
    }

    public static VariantProperty Parse(IVariantProperty source)
    {
        return new VariantProperty
        {
            Name = source.Name,
            Value = source.Value,
        };
    }

    public VariantPropertyResponse MapToResponse()
    {
        return new ()
        {
            Name = Name,
            Value = Value,
        };
    }

    public VariantPropertyRequest MapToRequest()
    {
        return new ()
        {
            Name = Name,
            Value = Value,
        };
    }

    public virtual object Clone()
    {
        return new VariantProperty()
        {
            Name = Name,
            Value = Value
        };
    }
}

public class VariantPropertyRequest : VariantProperty
{
    public VariantPropertyRequest() { }

    public VariantPropertyRequest(string name, string value) : base(name, value) { }

    public override object Clone()
    {
        return new VariantPropertyRequest()
        {
            Name = Name,
            Value = Value
        };
    }
}

public class VariantPropertyResponse : VariantProperty
{
    public VariantPropertyResponse() { }

    public VariantPropertyResponse(string name, string value) : base(name, value) { }
    
    public override object Clone()
    {
        return new VariantPropertyResponse()
        {
            Name = Name,
            Value = Value
        };
    }
}

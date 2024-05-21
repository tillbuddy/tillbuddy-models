namespace TillBuddy.Models;

public interface IVariantProperty
{
    public string Name { get; set; }
    public string Value { get; set; }
}

public class VariantProperty : IVariantProperty
{
    public string Name { get; set; } = null!;
    public string Value { get; set; } = null!;

    public VariantProperty Parse(IVariantProperty source)
    {
        return new VariantProperty
        {
            Name = source.Name,
            Value = source.Value,
        };
    }

}

public class VariantPropertyRequest : VariantProperty
{
}

public class VariantPropertyResponse : VariantProperty
{
}

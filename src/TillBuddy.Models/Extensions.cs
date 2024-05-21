namespace TillBuddy.Models;

public static class Extensions
{

    public static Dictionary<string, string> Clone(this IDictionary<string, string> original)
    {
        if (original == null)
        {
            throw new ArgumentNullException(nameof(original));
        }

        var clone = new Dictionary<string, string>();

        foreach (var kvp in original)
        {
            clone.Add(kvp.Key, kvp.Value);
        }

        return clone;
    }
}

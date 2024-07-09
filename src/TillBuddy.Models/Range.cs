namespace TillBuddy.Models;

public class Range<T> where T : IComparable<T>, ICloneable
{
    public T Lower { get; set; }
    public T Upper { get; set; }


    public Range(T lower, T upper)
    {
        Lower = lower;
        Upper = upper;
    }

    protected IEnumerable<object> GetEqualityComponents()
    {
        yield return Lower;
        yield return Upper;
    }
}
namespace TillBuddy.Models;

public class Range<T> : ValueObject
    where T : IComparable<T>
{
    public T Lower { get; }
    public T Upper { get; }


    public Range(T lower, T upper)
    {
        Lower = lower;
        Upper = upper;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Lower;
        yield return Upper;
    }
}
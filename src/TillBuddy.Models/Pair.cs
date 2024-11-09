namespace TillBuddy.Models;

public sealed class GenericPair<T1, T2> : IEquatable<GenericPair<T1, T2>>
{
    public T1 Id { get; set; }

    public T2 Name { get; set; }

    public GenericPair(T1 id, T2 name)
    {
        Id = id;
        Name = name;
    }

    public bool Equals(GenericPair<T1, T2>? other)
    {
        if (other == null) return false;
        if (!Id?.Equals(other.Id) ?? false) return false;
        if (!Name?.Equals(other.Name) ?? false) return false;

        return true;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as GenericPair<T1, T2>);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name);
    }
}


public sealed class Pair : IEquatable<Pair>
{
    public string Id { get; set; }

    public string Name { get; set; }

    public Pair(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public bool Equals(Pair? other)
    {
        if (other == null) return false;
        if (!Id?.Equals(other.Id) ?? false) return false;
        if (!Name?.Equals(other.Name) ?? false) return false;

        return true;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Pair);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name);
    }
}


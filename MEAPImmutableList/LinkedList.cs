// The difference between is record and a class is that a record is immutable by default, while a class is mutable.
// A record is a reference type that provides built-in functionality for value-based equality, immutability, and concise syntax
// for defining data structures. A class, on the other hand, is a more general-purpose reference type that can be mutable or
// immutable depending on how it is defined.
// To make a record mutable, you can use the `init` accessor for properties, which allows you to set the property values during
// object initialization but prevents modification afterward. However, if you want a truly mutable record, you can define properties
// with regular setters. Here's an example of a mutable record:
// Mutable record example
public record MutableRecord
{
    public string Name { get; set; }
    public int Age { get; set; }
}
// The same example as immutable redord would be:
// Immutable record example
//public record ImmutableRecord(string Name, int Age);


sealed record LinkedList<T>(T? Value, LinkedList<T>? Tail)
{
    public static LinkedList<T> Empty = new(default, null);
    public LinkedList<T> Push(T value) => new(value, this);
    public bool IsEmpty => this == Empty;
    public override string ToString()
    {
        var s = "";
        // the list.Tail! syntax means that we are asserting that list is not null,
        // which is safe because we check for IsEmpty before accessing Tail (the !list.Empty is afterall jsut negation.
        for (var list = this; !list.IsEmpty; list = list.Tail!)
            s += list.Value + " ";
        //This implementation is not efficient because it creates a new string every time
        //we concatenate, but it's just for demonstration purposes.
        return s;
    }

    public LinkedList<T> NaiveReverse()
    {
        var reversed = Empty;
        for (var list = this; !list.IsEmpty; list = list.Tail!)
            reversed = reversed.Push(list.Value!);
        return reversed;
    }

    public static LinkedList<int> Range(int N)
    {
        var list = LinkedList<int>.Empty;
        for (var i = N - 1; i >= 0; i--)
            list = list.Push(i);
        return list;
    }
}
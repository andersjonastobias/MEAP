using System.Runtime.CompilerServices;

namespace MEAPImmutableList;
class Program
{
    static void Main(string[] args)
    {
        // IMMUTABLE LINKED LIST
        var list = LinkedList<int>.Empty.Push(3).Push(2).Push(1);
        Console.WriteLine(list);
        var list1 = LinkedList<int>.Range(100000);
        var list2 = LinkedList<int>.Range(100000);
        //we are here trying to provoke a stack overflow by creating two large lists,
        //but since they are immutable and share the same structure, we can create as
        //many as we want without worrying about memory issues.
        //Console.WriteLine(list1 == list2);

        var list3 = LinkedList<int>.Empty.Push(10).Push(20).Push(30).Push(40).Push(50);
        var list4 = list3.NaiveReverse();
        Console.WriteLine(list3);
        Console.WriteLine(list4);
        
        Console.WriteLine("Hello, World!");

        //IMMUTABLE STACK
        var s1 = ImStack<int>.Empty;
        var s2 = s1.Push(10);
        var s3 = s2.Push(20);
        var s4 = s2.Push(30);
        var s5 = s4.Pop();
        var s6 = s5.Pop();
        Console.WriteLine(s1.Bracket());
        Console.WriteLine(s2.Bracket());
        Console.WriteLine(s3.Bracket());
        Console.WriteLine(s4.Bracket());
        Console.WriteLine(s5.Bracket());
        Console.WriteLine(s6.Bracket());

        // COVARIANT IMMUTABLE STACK
        IImStack<Tiger> s10 = ImStack<Tiger>.Empty;
        IImStack<Tiger> s20 = s10.Push(new Tiger());
        IImStack<Tiger> s30 = s20.Push(new Tiger());
        IImStack<Animal> s40 = s30;
        IImStack<Animal> s50 = s40.Push(new Giraffe());
        Console.WriteLine(s50.Bracket());

        // IMMUTABLE QUEUE
        var q1 = ImQueue<int>.Empty;
        var q2 = q1.Enqueue(10);
        var q3 = q2.Enqueue(20);
        var q4 = q3.Enqueue(30);
        var q5 = q4.Dequeue();
        var q6 = q5.Dequeue();
        var q7 = q6.Dequeue();
        Console.WriteLine(q1.Bracket());
        Console.WriteLine(q2.Bracket());
        Console.WriteLine(q3.Bracket());
        Console.WriteLine(q4.Bracket());
        Console.WriteLine(q5.Bracket());
        Console.WriteLine(q6.Bracket());
        Console.WriteLine(q7.Bracket());
    }
}

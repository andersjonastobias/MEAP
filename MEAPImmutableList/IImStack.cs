using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEAPImmutableList
{
    internal interface IImStack<out T> : IEnumerable<T>
    {
        // Remove to make ImStack covariant.
        //IImStack<T> Push(T value);

        // The Pop method returns a new stack with the top element removed,
        // and the Peek method returns the top element without modifying the stack.
        // This design allows us to work with immutable stacks, where each operation
        // returns a new instance of the stack rather than modifying the existing one.
        IImStack<T> Pop();
        T Peek();
        bool IsEmpty { get; }
    }
}

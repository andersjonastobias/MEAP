using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEAPImmutableList
{
    internal class ImStack<T> : IImStack<T>
    {
        private class EmptyStack : IImStack<T>
        {
            public bool IsEmpty => true;
            public IEnumerator<T> GetEnumerator()
            {
                yield break;
            }
            public T Peek()
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            public IImStack<T> Pop()
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            public IImStack<T> Push(T value)
            {
                return new ImStack<T>(value, this);
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        // Here we implement a singleton using static property. A cleaner
        // way to implement a singleton is to use a static constructor,
        // but this is just for demonstration purposes.
        public static IImStack<T> Empty { get; } = new EmptyStack();
        public bool IsEmpty => false;

        private readonly T item;
        private readonly IImStack<T> tail;

        public IEnumerator<T> GetEnumerator()
        {
            for (IImStack<T> s = this; !s.IsEmpty; s = s.Pop())
                yield return s.Peek();
        }

        private ImStack(T item, IImStack<T> tail)
        {
            this.item = item;
            this.tail = tail;
        }

        public T Peek() => item;

        public IImStack<T> Pop() => tail;

        //Since the stack is immutable, we might consider memoization of the push, ie constructor.
        //public IImStack<T> Push(T value) => new ImStack<T>(value, this);

        //By making the push method static, and taking it out of the interface, we can make sure the interface is 
        // covariant, and since the stack is immutable, we get covariance for free, since we never mutate, i.e. our T 
        // is always in the 'covariant position' in the homs.
        public static ImStack<T> Push(T item, IImStack<T> tail) => new ImStack<T>(item, tail);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

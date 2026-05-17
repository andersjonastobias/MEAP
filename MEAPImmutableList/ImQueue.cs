using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEAPImmutableList
{
    class ImQueue<T> : IImQueue<T>
    {
        public static IImQueue<T> Empty { get; } =
            new ImQueue<T>(ImStack<T>.Empty, ImStack<T>.Empty);
        private readonly IImStack<T> enqueues;
        private readonly IImStack<T> dequeues;
        private ImQueue(IImStack<T> enqueues, IImStack<T> dequeues)
        {
            this.enqueues = enqueues;
            this.dequeues = dequeues;
        }
        public IImQueue<T> Enqueue(T item) =>
            IsEmpty ?
            new ImQueue<T>(enqueues, dequeues.Push(item)) :
            new ImQueue<T>(enqueues.Push(item), dequeues);
        public T Peek() => dequeues.Peek();
        public IImQueue<T> Dequeue()
        {
            IImStack<T> newdeq = dequeues.Pop();
            if (!newdeq.IsEmpty)
                return new ImQueue<T>(enqueues, newdeq);
            if (enqueues.IsEmpty)
                return Empty;
            return new ImQueue<T>(ImStack<T>.Empty, enqueues.Reverse());
        }
        public bool IsEmpty => dequeues.IsEmpty;
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in dequeues)
                yield return item;
            foreach (var item in enqueues.Reverse())
                yield return item;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

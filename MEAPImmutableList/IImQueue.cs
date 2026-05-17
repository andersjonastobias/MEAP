using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEAPImmutableList
{
    interface IImQueue<T> : IEnumerable<T>
    {
        IImQueue<T> Enqueue(T item);
        T Peek();
        IImQueue<T> Dequeue();
        bool IsEmpty { get; }
    }
}

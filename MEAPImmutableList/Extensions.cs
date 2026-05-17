using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEAPImmutableList
{
    static class Extensions
    {
        public static string Comma<T>(this IEnumerable<T> items) =>
            string.Join(',', items);
        public static string Bracket<T>(this IEnumerable<T> items) =>
            "[" + items.Comma() + "]";

        public static IImStack<T> Push<T>(this IImStack<T> stack, T item) =>
            ImStack<T>.Push(item, stack);

        public static IImStack<T> Reverse<T>(this IImStack<T> stack)
        {
            var result = ImStack<T>.Empty;
            for (; !stack.IsEmpty; stack = stack.Pop())
                result = result.Push(stack.Peek());
            return result;
        }
    }
}

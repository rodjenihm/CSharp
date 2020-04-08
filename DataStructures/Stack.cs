using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class Stack<T> : IReadOnlyCollection<T>, IEnumerable<T>
    {
        public int Count => items.GetRange(0, sp + 1).Count;

        public Stack() : this(0)
        {
        }

        public Stack(IEnumerable<T> collection) : this(collection.Count())
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in collection)
            {
                Push(item);
            }
        }

        public Stack(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            items = new List<T>(capacity);
            sp = -1;
        }

        public void Clear()
        {
            items.Clear();
            sp = -1;
        }

        public bool Contains(T item)
        {
            return items.GetRange(0, sp + 1).Contains(item);
        }

        public void CopyTo(T[] array, int index)
        {
            items.GetRange(0, sp + 1).CopyTo(array, index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetRange(0, sp + 1).GetEnumerator();
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            return items[sp];
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            return items[sp--];
        }

        public void Push(T item)
        {
            items.Add(item);
            sp++;
        }

        public override string ToString()
        {
            var stackList = items.GetRange(0, sp + 1);

            stackList.Reverse();

            return stackList.ToString();
        }

        private readonly List<T> items;
        private int sp;

        private bool IsEmpty()
        {
            return sp == -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

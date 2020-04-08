using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Queue<T> : IReadOnlyCollection<T>, IEnumerable<T>
    {
        public int Count => items.GetRange(dp + 1, ep - dp).Count;

        public Queue() : this(0)
        {
        }

        public Queue(IEnumerable<T> collection) : this(collection.Count())
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in collection)
            {
                Enqueue(item);
            }
        }

        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            items = new List<T>(capacity);
            ep = -1;
            dp = -1;
        }

        public void Clear()
        {
            items.Clear();
            dp = ep = -1;
        }

        public bool Contains(T item)
        {
            return items.GetRange(dp + 1, ep - dp).Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            items.GetRange(dp + 1, ep - dp).CopyTo(array, arrayIndex);
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue empty");
            }

            var deq = items[++dp];

            // if IsEmpty reset pointers.
            // Otherwise dp and ep would continue to grow resulting in unnecessary array allocations
            // and bunch of unused space in the beginning of the array
            if (IsEmpty())
            {
                items.Clear();
                dp = ep = -1;
            }

            return deq;
        }

        public void Enqueue(T item)
        {
            items.Add(item);
            ep++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetRange(dp + 1, ep - dp).GetEnumerator();
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            return items[dp + 1];
        }

        public T[] ToArray()
        {
            return items.GetRange(dp + 1, ep - dp).ToArray();
        }

        public override string ToString()
        {
            return items.GetRange(dp + 1, ep - dp).ToString();
        }

        private readonly List<T> items;
        private int dp;
        private int ep;

        private bool IsEmpty()
        {
            return dp == ep;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

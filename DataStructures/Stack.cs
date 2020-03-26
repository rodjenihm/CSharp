using DataStructures.Extensions;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Stack<T> : ICollection<T>, IEnumerable<T>
    {
        public int Count => items.Count;

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

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            items.Clear();
            sp = -1;
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public void CopyTo(T[] array, int index)
        {
            items.CopyTo(array, index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
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

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append("{");

            for (int i = items.Count - 1; i >= 0; i--)
            {
                output.Append($"{items[i]},");
            }

            output.Append("}");

            return output.ToString();
        }

        private readonly List<T> items;
        private int sp;

        private bool IsEmpty()
        {
            return sp == -1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class ListEnumerator<T> : IEnumerator<T>
    {
        public T Current => items[idx];

        public ListEnumerator(T[] items, int count)
        {
            this.items = items;
            this.count = count;
            idx = -1;
        }

        public bool MoveNext()
        {
            return ++idx < count;
        }

        public void Reset()
        {
            idx = -1;
        }

        private readonly T[] items;
        private readonly int count;
        private int idx;
    }
}

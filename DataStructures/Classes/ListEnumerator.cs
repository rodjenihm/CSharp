using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class ListEnumerator<T> : IEnumerator<T>
    {
        public T Current => items[idx];

        object IEnumerator.Current => throw new NotImplementedException();

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

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private readonly T[] items;
        private readonly int count;
        private int idx;
    }
}

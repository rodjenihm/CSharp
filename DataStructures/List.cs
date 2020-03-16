using DataStructures.Extensions;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class List<T> : IList<T>, ICollection<T>, IEnumerable<T>
    {
        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => count;

        public int Capacity { get; set; } = 0;

        public List()
            : this(0)
        {
        }

        public List(IEnumerable<T> collection)
        {
            Capacity = collection.Count();
        }

        public List(int capacity)
        {
            Capacity = capacity;
            array = new T[capacity];
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        private int count = 0;
        private int idx = -1;
        private T[] array;
    }
}

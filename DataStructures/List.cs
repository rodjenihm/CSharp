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

        public int Capacity
        {
            get
            {
                return capacity;
            }

            set
            {
                if (value < capacity)
                {
                    throw new ArgumentOutOfRangeException("value", "capacity was less than the current size.");
                }
                else if (value > capacity)
                {
                    capacity = value;
                    ReallocateArray(value);
                }
            }
        }

        public List() : this(0)
        {
        }

        //public List(IEnumerable<T> collection) : this(collection.Count())
        //{
        //}

        public List(int capacity)
        {
            Capacity = capacity;
            array = new T[capacity];
        }

        public void Add(T item)
        {
            EnsureCapacity();

            array[count] = item;

            count++;
        }

        public void Clear()
        {
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    array[i] = default;
                }

                count = 0;
            }
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

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append("{");

            for (int i = 0; i < count; i++)
            {
                output.Append($"{array[i]},");
            }

            output.Append("}");

            return output.ToString();
        }

        private int count = 0;
        private int capacity;
        private T[] array;

        private bool ArrayFull()
        {
            return count == Capacity;
        }

        private void ReallocateArray(int capacity)
        {
            var newArray = new T[capacity];
            for (int i = 0; i < count; i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;

            this.capacity = capacity;
        }

        private int CalculateCapacity()
        {
            return capacity == 0 ? 4 : capacity * 2;
        }

        private void EnsureCapacity()
        {
            if (ArrayFull())
            {
                ReallocateArray(CalculateCapacity());
            }
        }
    }
}

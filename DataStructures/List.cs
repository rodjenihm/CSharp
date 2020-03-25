﻿using DataStructures.Extensions;
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

        public List(IEnumerable<T> collection) : this(collection.Count())
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public List(int capacity)
        {
            this.capacity = capacity;
            items = new T[capacity];
        }

        public void Add(T item)
        {
            EnsureCapacity();

            items[count] = item;

            count++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public void Clear()
        {
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    items[i] = default;
                }

                count = 0;
            }
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
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
            if (item == null)
            {
                for (int i = 0; i < count; i++)
                {
                    if (items[i] == null)
                    {
                        return i;
                    }
                }
            }
            else
            {
                var c = System.Collections.Generic.EqualityComparer<T>.Default;

                for (int i = 0; i < count; i++)
                {
                    if (c.Equals(items[i], item))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException();
            }

            EnsureCapacity();

            for (int i = index; i < count; i++)
            {
                items[i + 1] = items[i];
            }

            items[index] = item;

            count++;
        }

        public bool Remove(T item)
        {
            var itemIndex = IndexOf(item);

            if (itemIndex == -1)
            {
                return false;
            }

            RemoveAt(itemIndex);

            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[count - 1] = default;

            count--;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append("{");

            for (int i = 0; i < count; i++)
            {
                output.Append($"{items[i]},");
            }

            output.Append("}");

            return output.ToString();
        }

        private int count = 0;
        private int capacity;
        private T[] items;

        private bool ArrayFull()
        {
            return count == Capacity;
        }

        private void ReallocateArray(int capacity)
        {
            var newArray = new T[capacity];
            for (int i = 0; i < count; i++)
            {
                newArray[i] = items[i];
            }

            items = newArray;

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

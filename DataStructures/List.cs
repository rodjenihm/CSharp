using DataStructures.Extensions;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class List<T> : IList<T>, ICollection<T>, IEnumerable<T>
    {
        public T this[int index] { get => items[index]; set => items[index] = value; }

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
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

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

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (count > array.Length - arrayIndex)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < count; i++)
            {
                array[i + arrayIndex] = items[i];
            }
        }

        public void CopyTo(T[] array)
        {
            CopyTo(array, 0);
        }

        public bool Exists(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < count; i++)
            {
                if (match.Invoke(items[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public T Find(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < count; i++)
            {
                if (match.Invoke(items[i]))
                {
                    return items[i];
                }
            }

            return default;
        }

        public List<T> FindAll(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException();
            }

            var list = new List<T>();

            for (int i = 0; i < count; i++)
            {
                if (match.Invoke(items[i]))
                {
                    list.Add(items[i]);
                }
            }

            return list;
        }


        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(items, count);
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

        public void Reverse()
        {
            Array.Reverse(items, 0, count);
        }

        public T[] ToArray()
        {
            var array = new T[count];

            Array.Copy(items, array, count);

            return array;
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

        public bool TrueForAll(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < count; i++)
            {
                if (!match.Invoke(items[i]))
                {
                    return false;
                }
            }

            return true;
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

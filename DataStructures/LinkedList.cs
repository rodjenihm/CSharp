﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public partial class LinkedList<T> : ICollection<T>
    {
        public int Count => count;

        public LinkedListNode<T> First => first;

        public LinkedListNode<T> Last => last;

        public LinkedList()
        {
        }

        public LinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddLast(item);
                count++;
            }
        }

        public LinkedListNode<T> AddFirst(T value)
        {
            var newNode = new LinkedListNode<T>(value, previous: null, next: null);

            if (first == null)
            {
                first = last = newNode;
            }
            else
            {
                newNode.next = first;
                first.prev = newNode;
                first = newNode;
            }

            count++;

            return newNode;
        }

        public LinkedListNode<T> AddLast(T value)
        {
            var newNode = new LinkedListNode<T>(value, previous: null, next: null);

            if (first == null)
            {
                first = last = newNode;
            }
            else
            {
                newNode.prev = last;
                last.next = newNode;
                last = newNode;
            }

            count++;

            return newNode;
        }

        public void Clear()
        {
            var iter = first;

            while (iter != null)
            {
                var temp = iter;
                iter = iter.next;
                temp.prev = null;
                temp.next = null;
            }

            first = last = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            var iter = first;

            if (item == null)
            {
                while (iter != null)
                {
                    if (iter.val == null)
                    {
                        return true;
                    }

                    iter = iter.next;
                }
            }
            else
            {
                var c = System.Collections.Generic.Comparer<T>.Default;

                while (iter != null)
                {
                    if (c.Compare(iter.Value, item) == 0)
                    {
                        return true;
                    }

                    iter = iter.next;
                }
            }

            return false;
        }

        public LinkedListNode<T> Find(T value)
        {
            var iter = first;

            var c = System.Collections.Generic.Comparer<T>.Default;

            while (iter != null)
            {
                if (c.Compare(iter.Value, value) == 0)
                {
                    break;
                }

                iter = iter.next;
            }

            return iter;
        }

        public LinkedListNode<T> FindLast(T value)
        {
            var iter = last;

            var c = System.Collections.Generic.Comparer<T>.Default;

            while (iter != null)
            {
                if (c.Compare(iter.Value, value) == 0)
                {
                    break;
                }

                iter = iter.prev;
            }

            return iter;
        }

        void ICollection<T>.Add(T item)
        {
            AddLast(item);
        }

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (index + count > array.Length)
            {
                throw new ArgumentException();
            }

            var iter = first;

            for (int i = index; i < index + count; i++, iter = iter.next)
            {
                array[i] = iter.Value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append("{");

            var iter = first;

            while (iter != null)
            {
                output.Append($"{iter.Value},");
                iter = iter.next;
            }

            output.Append("}");

            return output.ToString();
        }

        private int count = 0;
        private LinkedListNode<T> first = null;
        private LinkedListNode<T> last = null;
    }
}
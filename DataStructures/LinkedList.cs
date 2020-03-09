using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public partial class LinkedList<T> : ICollection<T>
    {
        public int Count
        {
            get
            {
                return count;
            }
        }

        public LinkedListNode<T> First
        {
            get
            {
                return first;
            }
        }

        public LinkedListNode<T> Last
        {
            get
            {
                return last;
            }
        }

        public LinkedList()
        {
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
                while (iter != null)
                {
                    if (iter.val.Equals(item))
                    {
                        return true;
                    }

                    iter = iter.next;
                }
            }

            return false;
        }

        void ICollection<T>.Add(T item)
        {
            AddLast(item);
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

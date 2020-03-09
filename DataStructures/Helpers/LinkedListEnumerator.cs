using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class LinkedListEnumerator<T> : IEnumerator<T>
    {
        public T Current => iter.Value;

        public LinkedListEnumerator(LinkedList<T> linkedList)
        {
            this.linkedList = linkedList;
            Reset();
        }

        public bool MoveNext()
        {
            if (reset)
            {
                reset = false;
                iter = linkedList.First;
                return iter != null;
            }

            iter = iter.next;
            return iter != null;
        }

        public void Reset()
        {
            reset = true;
        }

        private readonly LinkedList<T> linkedList;
        private LinkedListNode<T> iter;
        private bool reset;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class LinkedListEnumerator<T> : IEnumerator<T>
    {
        public T Current => iter.Value;

        object IEnumerator.Current => throw new NotImplementedException();

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

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private readonly LinkedList<T> linkedList;
        private LinkedListNode<T> iter;
        private bool reset;
    }
}

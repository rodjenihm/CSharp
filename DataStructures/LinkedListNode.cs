namespace DataStructures
{
    public class LinkedListNode<T>
    {
        public LinkedListNode<T> Next
        {
            get
            {
                return next;
            }
        }

        public LinkedListNode<T> Previous
        {
            get
            {
                return prev;
            }
        }

        public T Value
        {
            get
            {
                return val;
            }

            set
            {
                val = value;
            }
        }


        public LinkedListNode()
            : this(default, null, null)
        {
        }

        public LinkedListNode(T value)
            : this(value, null, null)
        {
        }

        public LinkedListNode(T value, LinkedListNode<T> previous, LinkedListNode<T> next)
        {
            val = value;
            prev = previous;
            this.next = next;
        }

        internal LinkedListNode<T> next;
        internal LinkedListNode<T> prev;
        internal T val;
    }
}

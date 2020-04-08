using System;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataStructures
{
    public class QueueShould
    {
        private readonly Queue<int> queue;

        public QueueShould()
        {
            queue = new Queue<int>();
        }

        [Fact]
        public void HaveCountOfZeroIfEmpty()
        {
            Assert.Empty(queue);
        }

        [Fact]
        public void EnqueueElement()
        {
            queue.Enqueue(1);

            Assert.Single(queue);

            queue.Enqueue(2);

            Assert.Equal(2, queue.Count);

            queue.Enqueue(3);

            Assert.Equal(3, queue.Count);
        }

        [Fact]
        public void DequeueElement()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.Equal(1, queue.Dequeue());
            Assert.Equal(2, queue.Dequeue());
            Assert.Equal(3, queue.Dequeue());
        }

        [Fact]
        public void PeekElement()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.Equal(1, queue.Peek());

            queue.Dequeue();

            Assert.Equal(2, queue.Peek());

            queue.Dequeue();

            Assert.Equal(3, queue.Peek());
        }

        [Fact]
        public void ClearElements()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            queue.Clear();

            Assert.Empty(queue);
        }

        [Fact]
        public void ReturnTrueIfContainsElement()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.True(queue.Contains(1));
            Assert.True(queue.Contains(2));
            Assert.True(queue.Contains(3));
            Assert.False(queue.Contains(4));
        }

        [Fact]
        public void ThrowExceptionIfDequeuingWhileBeingEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Fact]
        public void ThrowExceptionIfPeekingWhileBeingEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Fact]
        public void EnumerateElements()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            var enumerator = queue.GetEnumerator();

            Assert.NotNull(enumerator);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(1, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(2, enumerator.Current);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(3, enumerator.Current);

            Assert.False(enumerator.MoveNext());
        }
    }
}

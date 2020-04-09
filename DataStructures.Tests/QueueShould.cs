using System;
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

        [Theory]
        [MemberData(nameof(QueueShouldTestData.CountElementsData), MemberType = typeof(QueueShouldTestData))]
        public void CountElements<T>(Queue<T> queue, int count)
        {
            Assert.Equal(count, queue.Count);
        }

        [Theory]
        [MemberData(nameof(QueueShouldTestData.EnqueueElementData), MemberType = typeof(QueueShouldTestData))]
        public void EnqueueElement<T>(Queue<T> queue, T elementToEnqueue, int countAfterEnqueuing)
        {
            queue.Enqueue(elementToEnqueue);

            Assert.Equal(countAfterEnqueuing, queue.Count);
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

            Assert.Equal(0, queue.Count);
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

        [Theory]
        [MemberData(nameof(QueueShouldTestData.ThrowExceptionIfDequeuingOrPeekingWhileBeingEmptyData),
            MemberType = typeof(QueueShouldTestData))]
        public void ThrowExceptionIfDequeuingWhileBeingEmpty<T>(Queue<T> queue)
        {
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Theory]
        [MemberData(nameof(QueueShouldTestData.ThrowExceptionIfDequeuingOrPeekingWhileBeingEmptyData),
            MemberType = typeof(QueueShouldTestData))]
        public void ThrowExceptionIfPeekingWhileBeingEmpty<T>(Queue<T> queue)
        {
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
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

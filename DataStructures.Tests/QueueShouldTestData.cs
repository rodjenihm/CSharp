using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class QueueShouldTestData
    {
        public static System.Collections.Generic.IEnumerable<object[]> CountElementsData
        {
            get
            {
                yield return new object[] { new Queue<int>(), 0 };

                var queueOfInts = new Queue<int>(new int[] { 1, 2, 3 });
                yield return new object[] { queueOfInts, 3 };

                var queueOfStrings = new Queue<string>(new string[] { "a", "b" });
                yield return new object[] { queueOfStrings, 2 };
            }
        }

        public static System.Collections.Generic.IEnumerable<object[]> ThrowExceptionIfDequeuingOrPeekingWhileBeingEmptyData
        {
            get
            {
                yield return new object[] { new Queue<int>() };
                yield return new object[] { new Queue<string>() };
            }
        }

        public static System.Collections.Generic.IEnumerable<object[]> EnqueueElementData
        {
            get
            {
                // queue, elemnt to be Enqueued, queue count after Enqueuing is performed
                yield return new object[] { new Queue<int>(), 9, 1 };
                yield return new object[] { new Queue<int>(new int[] { 1, 2, 3 }), 7, 4 };
                yield return new object[] { new Queue<string>(new string[] { "a", "b" }), "c", 3 };
            }
        }
    }
}
